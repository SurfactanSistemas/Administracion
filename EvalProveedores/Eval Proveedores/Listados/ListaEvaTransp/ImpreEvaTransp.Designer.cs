namespace Eval_Proveedores.Listados.ListaEvaTransp
{
    partial class ImpreEvaTransp
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
            this.CRVEvaTransp = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVEvaTransp
            // 
            this.CRVEvaTransp.ActiveViewIndex = -1;
            this.CRVEvaTransp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVEvaTransp.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVEvaTransp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVEvaTransp.Location = new System.Drawing.Point(0, 0);
            this.CRVEvaTransp.Name = "CRVEvaTransp";
            this.CRVEvaTransp.ShowCloseButton = false;
            this.CRVEvaTransp.ShowGotoPageButton = false;
            this.CRVEvaTransp.ShowGroupTreeButton = false;
            this.CRVEvaTransp.ShowLogo = false;
            this.CRVEvaTransp.ShowParameterPanelButton = false;
            this.CRVEvaTransp.ShowRefreshButton = false;
            this.CRVEvaTransp.Size = new System.Drawing.Size(784, 562);
            this.CRVEvaTransp.TabIndex = 0;
            this.CRVEvaTransp.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreEvaTransp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVEvaTransp);
            this.Name = "ImpreEvaTransp";
            this.Load += new System.EventHandler(this.ImpreEvaTransp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVEvaTransp;
    }
}