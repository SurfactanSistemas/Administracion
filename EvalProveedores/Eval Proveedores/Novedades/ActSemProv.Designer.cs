namespace Eval_Proveedores.Novedades
{
    partial class ActSemProv
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_TitEva = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BT_Salir = new System.Windows.Forms.Button();
            this.BT_Guardar = new System.Windows.Forms.Button();
            this.LB_Titulo = new System.Windows.Forms.Label();
            this.CB_TipoEva = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DGV_EvalSemProve = new System.Windows.Forms.DataGridView();
            this.CodigoProve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desviad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rechaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Envi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorCert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorEnv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaCal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EvaEnt = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.TB_Hasta = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Desde = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.LB_TitEva);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 39);
            this.panel1.TabIndex = 4;
            // 
            // LB_TitEva
            // 
            this.LB_TitEva.AutoSize = true;
            this.LB_TitEva.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_TitEva.ForeColor = System.Drawing.Color.White;
            this.LB_TitEva.Location = new System.Drawing.Point(22, 11);
            this.LB_TitEva.Name = "LB_TitEva";
            this.LB_TitEva.Size = new System.Drawing.Size(441, 19);
            this.LB_TitEva.TabIndex = 0;
            this.LB_TitEva.Text = "ACTUALIZACION DE EVALUACION SEMESTRAL DE PROVEEDORES";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(1, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 649);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BT_Salir);
            this.panel3.Controls.Add(this.BT_Guardar);
            this.panel3.Controls.Add(this.LB_Titulo);
            this.panel3.Controls.Add(this.CB_TipoEva);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DGV_EvalSemProve);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.TB_Hasta);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.TB_Desde);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(851, 511);
            this.panel3.TabIndex = 0;
            // 
            // BT_Salir
            // 
            this.BT_Salir.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Fin21;
            this.BT_Salir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Salir.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Salir.Location = new System.Drawing.Point(452, 458);
            this.BT_Salir.Name = "BT_Salir";
            this.BT_Salir.Size = new System.Drawing.Size(40, 40);
            this.BT_Salir.TabIndex = 79;
            this.toolTip1.SetToolTip(this.BT_Salir, "Fin");
            this.BT_Salir.UseVisualStyleBackColor = true;
            this.BT_Salir.Click += new System.EventHandler(this.BT_Salir_Click);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.BackgroundImage = global::Eval_Proveedores.Properties.Resources.Grabar;
            this.BT_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Guardar.ForeColor = System.Drawing.SystemColors.Control;
            this.BT_Guardar.Location = new System.Drawing.Point(341, 458);
            this.BT_Guardar.Margin = new System.Windows.Forms.Padding(0);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(40, 40);
            this.BT_Guardar.TabIndex = 77;
            this.toolTip1.SetToolTip(this.BT_Guardar, "Guardar");
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // LB_Titulo
            // 
            this.LB_Titulo.AutoSize = true;
            this.LB_Titulo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Titulo.Location = new System.Drawing.Point(13, 74);
            this.LB_Titulo.Name = "LB_Titulo";
            this.LB_Titulo.Size = new System.Drawing.Size(171, 18);
            this.LB_Titulo.TabIndex = 12;
            this.LB_Titulo.Text = "LISTADO DE PROVEEDORES";
            // 
            // CB_TipoEva
            // 
            this.CB_TipoEva.FormattingEnabled = true;
            this.CB_TipoEva.Items.AddRange(new object[] {
            "CALIDAD",
            "ENTREGA"});
            this.CB_TipoEva.Location = new System.Drawing.Point(538, 22);
            this.CB_TipoEva.Name = "CB_TipoEva";
            this.CB_TipoEva.Size = new System.Drawing.Size(147, 21);
            this.CB_TipoEva.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Evaluación de:";
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
            this.Item,
            this.Aprobad,
            this.Desviad,
            this.Rechaz,
            this.Certific,
            this.Envi,
            this.PorCert,
            this.PorEnv,
            this.PorcTotal,
            this.Atra,
            this.Fechas,
            this.Cate1,
            this.Cate2,
            this.EvaCal,
            this.EvaEnt});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_EvalSemProve.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_EvalSemProve.Location = new System.Drawing.Point(16, 103);
            this.DGV_EvalSemProve.Name = "DGV_EvalSemProve";
            this.DGV_EvalSemProve.Size = new System.Drawing.Size(822, 341);
            this.DGV_EvalSemProve.TabIndex = 9;
            this.DGV_EvalSemProve.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_EvalSemProve_RowHeaderMouseDoubleClick);
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
            this.Descripcion.Width = 130;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Items";
            this.Item.HeaderText = "Items";
            this.Item.Name = "Item";
            this.Item.Width = 40;
            // 
            // Aprobad
            // 
            this.Aprobad.DataPropertyName = "Aprobado";
            this.Aprobad.HeaderText = "Aprob.";
            this.Aprobad.Name = "Aprobad";
            this.Aprobad.Width = 40;
            // 
            // Desviad
            // 
            this.Desviad.DataPropertyName = "Desviado";
            this.Desviad.HeaderText = "Desv.";
            this.Desviad.Name = "Desviad";
            this.Desviad.Width = 40;
            // 
            // Rechaz
            // 
            this.Rechaz.DataPropertyName = "Rechazado";
            this.Rechaz.HeaderText = "Rech.";
            this.Rechaz.Name = "Rechaz";
            this.Rechaz.Width = 40;
            // 
            // Certific
            // 
            this.Certific.DataPropertyName = "Certificado";
            this.Certific.HeaderText = "Cert.";
            this.Certific.Name = "Certific";
            this.Certific.Width = 40;
            // 
            // Envi
            // 
            this.Envi.DataPropertyName = "Enviado";
            this.Envi.HeaderText = "Env.";
            this.Envi.Name = "Envi";
            this.Envi.Width = 40;
            // 
            // PorCert
            // 
            this.PorCert.DataPropertyName = "PorcCert";
            this.PorCert.HeaderText = "%Cert.";
            this.PorCert.Name = "PorCert";
            this.PorCert.Width = 40;
            // 
            // PorEnv
            // 
            this.PorEnv.DataPropertyName = "PorcEnv";
            this.PorEnv.HeaderText = "%Env.";
            this.PorEnv.Name = "PorEnv";
            this.PorEnv.Width = 40;
            // 
            // PorcTotal
            // 
            this.PorcTotal.DataPropertyName = "PorcTotal";
            this.PorcTotal.HeaderText = "%";
            this.PorcTotal.Name = "PorcTotal";
            this.PorcTotal.Width = 40;
            // 
            // Atra
            // 
            this.Atra.DataPropertyName = "Atraso";
            this.Atra.HeaderText = "Atraso";
            this.Atra.Name = "Atra";
            this.Atra.Width = 40;
            // 
            // Fechas
            // 
            this.Fechas.DataPropertyName = "Fecha";
            this.Fechas.HeaderText = "Fecha";
            this.Fechas.Name = "Fechas";
            this.Fechas.Width = 80;
            // 
            // Cate1
            // 
            this.Cate1.DataPropertyName = "Categoria1";
            this.Cate1.HeaderText = "Calidad";
            this.Cate1.Name = "Cate1";
            this.Cate1.Width = 70;
            // 
            // Cate2
            // 
            this.Cate2.DataPropertyName = "Categoria2";
            this.Cate2.HeaderText = "Entrega";
            this.Cate2.Name = "Cate2";
            this.Cate2.Width = 70;
            // 
            // EvaCal
            // 
            this.EvaCal.HeaderText = "Evaluacion";
            this.EvaCal.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.EvaCal.Name = "EvaCal";
            this.EvaCal.Width = 80;
            // 
            // EvaEnt
            // 
            this.EvaEnt.HeaderText = "Evaluacion";
            this.EvaEnt.Items.AddRange(new object[] {
            "Muy Bueno",
            "Bueno",
            "Regular",
            "Malo",
            "Sin Calificar"});
            this.EvaEnt.Name = "EvaEnt";
            this.EvaEnt.Width = 80;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Eval_Proveedores.Properties.Resources.buscar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(736, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 48);
            this.button1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button1, "Buscar");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TB_Hasta
            // 
            this.TB_Hasta.Location = new System.Drawing.Point(281, 24);
            this.TB_Hasta.Mask = "00/00/0000";
            this.TB_Hasta.Name = "TB_Hasta";
            this.TB_Hasta.Size = new System.Drawing.Size(100, 20);
            this.TB_Hasta.TabIndex = 6;
            this.TB_Hasta.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hasta:";
            // 
            // TB_Desde
            // 
            this.TB_Desde.Location = new System.Drawing.Point(71, 23);
            this.TB_Desde.Mask = "00/00/0000";
            this.TB_Desde.Name = "TB_Desde";
            this.TB_Desde.Size = new System.Drawing.Size(100, 20);
            this.TB_Desde.TabIndex = 4;
            this.TB_Desde.ValidatingType = typeof(System.DateTime);
            this.TB_Desde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Desde_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Desde:";
            // 
            // ActSemProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(868, 563);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(884, 601);
            this.MinimumSize = new System.Drawing.Size(884, 601);
            this.Name = "ActSemProv";
            this.Load += new System.EventHandler(this.ActSemProv_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_EvalSemProve)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_TitEva;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MaskedTextBox TB_Hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TB_Desde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DGV_EvalSemProve;
        private System.Windows.Forms.ComboBox CB_TipoEva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_Titulo;
        private System.Windows.Forms.Button BT_Guardar;
        private System.Windows.Forms.Button BT_Salir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProve;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aprobad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desviad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rechaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certific;
        private System.Windows.Forms.DataGridViewTextBoxColumn Envi;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorCert;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorEnv;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cate2;
        private System.Windows.Forms.DataGridViewComboBoxColumn EvaCal;
        private System.Windows.Forms.DataGridViewComboBoxColumn EvaEnt;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}