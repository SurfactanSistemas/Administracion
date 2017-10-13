namespace Vista
{
    partial class Etiquetas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GrupoIdiomaEtiquetas = new System.Windows.Forms.GroupBox();
            this.cmbIdiomaEtiquetas = new System.Windows.Forms.ComboBox();
            this.CBPosicion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DGV_Etiquetas = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBTamañoEtiquetas = new System.Windows.Forms.ComboBox();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTipAceptar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipCancelar = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.GrupoIdiomaEtiquetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Etiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(139)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 42);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "IMPRESION ETIQUETAS DE MUESTRA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(3, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 333);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.GrupoIdiomaEtiquetas);
            this.panel3.Controls.Add(this.CBPosicion);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DGV_Etiquetas);
            this.panel3.Controls.Add(this.CBTamañoEtiquetas);
            this.panel3.Controls.Add(this.BTCancelar);
            this.panel3.Controls.Add(this.BTAceptar);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 320);
            this.panel3.TabIndex = 0;
            // 
            // GrupoIdiomaEtiquetas
            // 
            this.GrupoIdiomaEtiquetas.Controls.Add(this.cmbIdiomaEtiquetas);
            this.GrupoIdiomaEtiquetas.Location = new System.Drawing.Point(84, 259);
            this.GrupoIdiomaEtiquetas.Name = "GrupoIdiomaEtiquetas";
            this.GrupoIdiomaEtiquetas.Size = new System.Drawing.Size(200, 55);
            this.GrupoIdiomaEtiquetas.TabIndex = 12;
            this.GrupoIdiomaEtiquetas.TabStop = false;
            this.GrupoIdiomaEtiquetas.Text = "Idioma de Estiquetas";
            // 
            // cmbIdiomaEtiquetas
            // 
            this.cmbIdiomaEtiquetas.DisplayMember = "Etiqueta Chica (8.5 x 4)";
            this.cmbIdiomaEtiquetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdiomaEtiquetas.FormattingEnabled = true;
            this.cmbIdiomaEtiquetas.Items.AddRange(new object[] {
            "Español",
            "Inglés"});
            this.cmbIdiomaEtiquetas.Location = new System.Drawing.Point(23, 21);
            this.cmbIdiomaEtiquetas.Name = "cmbIdiomaEtiquetas";
            this.cmbIdiomaEtiquetas.Size = new System.Drawing.Size(154, 21);
            this.cmbIdiomaEtiquetas.TabIndex = 7;
            this.cmbIdiomaEtiquetas.ValueMember = "Etiqueta Chica (8.5 x 4)";
            this.cmbIdiomaEtiquetas.SelectedIndexChanged += new System.EventHandler(this.cmbIdiomaEtiquetas_SelectedIndexChanged);
            // 
            // CBPosicion
            // 
            this.CBPosicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBPosicion.FormattingEnabled = true;
            this.CBPosicion.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.CBPosicion.Location = new System.Drawing.Point(443, 27);
            this.CBPosicion.Name = "CBPosicion";
            this.CBPosicion.Size = new System.Drawing.Size(79, 21);
            this.CBPosicion.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "A partir de Posición:";
            // 
            // DGV_Etiquetas
            // 
            this.DGV_Etiquetas.AllowUserToAddRows = false;
            this.DGV_Etiquetas.AllowUserToDeleteRows = false;
            this.DGV_Etiquetas.CausesValidation = false;
            this.DGV_Etiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Etiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.Cantidad});
            this.DGV_Etiquetas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGV_Etiquetas.Location = new System.Drawing.Point(15, 61);
            this.DGV_Etiquetas.Name = "DGV_Etiquetas";
            this.DGV_Etiquetas.Size = new System.Drawing.Size(515, 192);
            this.DGV_Etiquetas.TabIndex = 9;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 275;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 97;
            // 
            // CBTamañoEtiquetas
            // 
            this.CBTamañoEtiquetas.DisplayMember = "Etiqueta Chica (8.5 x 4)";
            this.CBTamañoEtiquetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTamañoEtiquetas.FormattingEnabled = true;
            this.CBTamañoEtiquetas.Items.AddRange(new object[] {
            "Etiqueta Chica (8.5 x 4)",
            "Etiqueta Autoadhesiva ( ZT-001-100)",
            "Etiqueta P/Frascos "});
            this.CBTamañoEtiquetas.Location = new System.Drawing.Point(97, 27);
            this.CBTamañoEtiquetas.Name = "CBTamañoEtiquetas";
            this.CBTamañoEtiquetas.Size = new System.Drawing.Size(177, 21);
            this.CBTamañoEtiquetas.TabIndex = 7;
            this.CBTamañoEtiquetas.ValueMember = "Etiqueta Chica (8.5 x 4)";
            this.CBTamañoEtiquetas.SelectedIndexChanged += new System.EventHandler(this.CBTamañoEtiquetas_SelectedIndexChanged);
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackgroundImage = global::Vista.Properties.Resources.Cancelar_N1;
            this.BTCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTCancelar.FlatAppearance.BorderSize = 0;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Location = new System.Drawing.Point(331, 264);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(53, 45);
            this.BTCancelar.TabIndex = 6;
            this.toolTipCancelar.SetToolTip(this.BTCancelar, "Cancelar");
            this.BTCancelar.UseVisualStyleBackColor = true;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // BTAceptar
            // 
            this.BTAceptar.BackgroundImage = global::Vista.Properties.Resources.Aceptar_N1;
            this.BTAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAceptar.FlatAppearance.BorderSize = 0;
            this.BTAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAceptar.Location = new System.Drawing.Point(416, 264);
            this.BTAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.BTAceptar.Name = "BTAceptar";
            this.BTAceptar.Size = new System.Drawing.Size(53, 45);
            this.BTAceptar.TabIndex = 5;
            this.toolTipAceptar.SetToolTip(this.BTAceptar, "Aceptar");
            this.BTAceptar.UseVisualStyleBackColor = true;
            this.BTAceptar.Click += new System.EventHandler(this.BTAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tamaño:";
            // 
            // Etiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 373);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Etiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.GrupoIdiomaEtiquetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Etiquetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTAceptar;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.ComboBox CBTamañoEtiquetas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTipCancelar;
        private System.Windows.Forms.ToolTip toolTipAceptar;
        protected System.Windows.Forms.DataGridView DGV_Etiquetas;
        private System.Windows.Forms.ComboBox CBPosicion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.GroupBox GrupoIdiomaEtiquetas;
        private System.Windows.Forms.ComboBox cmbIdiomaEtiquetas;
    }
}