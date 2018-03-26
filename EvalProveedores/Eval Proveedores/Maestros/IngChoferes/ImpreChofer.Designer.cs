namespace Eval_Proveedores.Maestros.IngChoferes
{
    partial class ImpreChofer
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
            this.CRV_Chofer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRV_Chofer
            // 
            this.CRV_Chofer.ActiveViewIndex = -1;
            this.CRV_Chofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV_Chofer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRV_Chofer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV_Chofer.Location = new System.Drawing.Point(0, 0);
            this.CRV_Chofer.Name = "CRV_Chofer";
            this.CRV_Chofer.ShowCloseButton = false;
            this.CRV_Chofer.ShowLogo = false;
            this.CRV_Chofer.Size = new System.Drawing.Size(714, 462);
            this.CRV_Chofer.TabIndex = 0;
            this.CRV_Chofer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 462);
            this.Controls.Add(this.CRV_Chofer);
            this.Name = "ImpreChofer";
            this.Load += new System.EventHandler(this.ImpreChofer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV_Chofer;
    }
}