namespace Eval_Proveedores.Maestros.IngCamiones
{
    partial class ImpreCamion
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
            this.CRV_Camion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRV_Camion
            // 
            this.CRV_Camion.ActiveViewIndex = -1;
            this.CRV_Camion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV_Camion.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRV_Camion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV_Camion.Location = new System.Drawing.Point(0, 0);
            this.CRV_Camion.Name = "CRV_Camion";
            this.CRV_Camion.ShowCloseButton = false;
            this.CRV_Camion.ShowLogo = false;
            this.CRV_Camion.Size = new System.Drawing.Size(714, 462);
            this.CRV_Camion.TabIndex = 1;
            this.CRV_Camion.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreCamion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 462);
            this.Controls.Add(this.CRV_Camion);
            this.Name = "ImpreCamion";
            this.Text = "ImpreCamion";
            this.Load += new System.EventHandler(this.ImpreCamion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV_Camion;
    }
}