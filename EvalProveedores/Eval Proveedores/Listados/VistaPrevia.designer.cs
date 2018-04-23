namespace Eval_Proveedores.Listados
{
    partial class VistaPrevia
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
            this.CRVInforme = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVInforme
            // 
            this.CRVInforme.ActiveViewIndex = -1;
            this.CRVInforme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVInforme.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVInforme.Location = new System.Drawing.Point(0, 0);
            this.CRVInforme.Name = "CRVInforme";
            this.CRVInforme.ShowCloseButton = false;
            this.CRVInforme.ShowGotoPageButton = false;
            this.CRVInforme.ShowGroupTreeButton = false;
            this.CRVInforme.ShowLogo = false;
            this.CRVInforme.ShowParameterPanelButton = false;
            this.CRVInforme.ShowRefreshButton = false;
            this.CRVInforme.Size = new System.Drawing.Size(784, 562);
            this.CRVInforme.TabIndex = 2;
            this.CRVInforme.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // VistaPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVInforme);
            this.Name = "VistaPrevia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVInforme;
    }
}