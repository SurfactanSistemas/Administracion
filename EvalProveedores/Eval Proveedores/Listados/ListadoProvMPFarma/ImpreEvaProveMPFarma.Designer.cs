namespace Eval_Proveedores.Listados.ListadoProvMPFarma
{
    partial class ImpreEvaProveMPFarma
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
            this.CRVEvaSemProveEnv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVEvaSemProveEnv
            // 
            this.CRVEvaSemProveEnv.ActiveViewIndex = -1;
            this.CRVEvaSemProveEnv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVEvaSemProveEnv.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVEvaSemProveEnv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVEvaSemProveEnv.Location = new System.Drawing.Point(0, 0);
            this.CRVEvaSemProveEnv.Name = "CRVEvaSemProveEnv";
            this.CRVEvaSemProveEnv.ShowCloseButton = false;
            this.CRVEvaSemProveEnv.ShowGotoPageButton = false;
            this.CRVEvaSemProveEnv.ShowGroupTreeButton = false;
            this.CRVEvaSemProveEnv.ShowLogo = false;
            this.CRVEvaSemProveEnv.ShowParameterPanelButton = false;
            this.CRVEvaSemProveEnv.ShowRefreshButton = false;
            this.CRVEvaSemProveEnv.Size = new System.Drawing.Size(784, 562);
            this.CRVEvaSemProveEnv.TabIndex = 2;
            this.CRVEvaSemProveEnv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreEvaProveEnv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVEvaSemProveEnv);
            this.Name = "ImpreEvaProveEnv";
            this.Load += new System.EventHandler(this.ImpreEvaProveEnv_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVEvaSemProveEnv;
    }
}