namespace Eval_Proveedores.Listados.EvaSemActProve
{
    partial class ImpreEvaSemProve
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
            this.CRVEvaSemProve = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVEvaSemProve
            // 
            this.CRVEvaSemProve.ActiveViewIndex = -1;
            this.CRVEvaSemProve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVEvaSemProve.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVEvaSemProve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVEvaSemProve.Location = new System.Drawing.Point(0, 0);
            this.CRVEvaSemProve.Name = "CRVEvaSemProve";
            this.CRVEvaSemProve.ShowCloseButton = false;
            this.CRVEvaSemProve.ShowGotoPageButton = false;
            this.CRVEvaSemProve.ShowGroupTreeButton = false;
            this.CRVEvaSemProve.ShowLogo = false;
            this.CRVEvaSemProve.ShowParameterPanelButton = false;
            this.CRVEvaSemProve.ShowRefreshButton = false;
            this.CRVEvaSemProve.Size = new System.Drawing.Size(784, 562);
            this.CRVEvaSemProve.TabIndex = 1;
            this.CRVEvaSemProve.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreEvaSemProve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVEvaSemProve);
            this.Name = "ImpreEvaSemProve";
            this.Load += new System.EventHandler(this.ImpreEvaSemProve_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVEvaSemProve;
    }
}