namespace Eval_Proveedores.Listados.ProvRubro
{
    partial class ImpreProve
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
            this.CRVListProve = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVListProve
            // 
            this.CRVListProve.ActiveViewIndex = -1;
            this.CRVListProve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVListProve.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVListProve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVListProve.Location = new System.Drawing.Point(0, 0);
            this.CRVListProve.Name = "CRVListProve";
            this.CRVListProve.ShowCloseButton = false;
            this.CRVListProve.ShowGotoPageButton = false;
            this.CRVListProve.ShowGroupTreeButton = false;
            this.CRVListProve.ShowLogo = false;
            this.CRVListProve.ShowParameterPanelButton = false;
            this.CRVListProve.ShowRefreshButton = false;
            this.CRVListProve.Size = new System.Drawing.Size(784, 562);
            this.CRVListProve.TabIndex = 0;
            this.CRVListProve.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreProve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVListProve);
            this.Name = "ImpreProve";
            this.Load += new System.EventHandler(this.ImpreProve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVListProve;
    }
}