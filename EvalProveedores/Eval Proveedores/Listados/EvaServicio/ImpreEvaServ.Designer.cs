namespace Eval_Proveedores.Listados.EvaServicio
{
    partial class ImpreEvaServ
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
            this.CRVEvaServ = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVEvaServ
            // 
            this.CRVEvaServ.ActiveViewIndex = -1;
            this.CRVEvaServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVEvaServ.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVEvaServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVEvaServ.Location = new System.Drawing.Point(0, 0);
            this.CRVEvaServ.Name = "CRVEvaServ";
            this.CRVEvaServ.ShowCloseButton = false;
            this.CRVEvaServ.ShowGotoPageButton = false;
            this.CRVEvaServ.ShowGroupTreeButton = false;
            this.CRVEvaServ.ShowLogo = false;
            this.CRVEvaServ.ShowParameterPanelButton = false;
            this.CRVEvaServ.ShowRefreshButton = false;
            this.CRVEvaServ.Size = new System.Drawing.Size(784, 562);
            this.CRVEvaServ.TabIndex = 1;
            this.CRVEvaServ.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreEvaServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVEvaServ);
            this.Name = "ImpreEvaServ";
            this.Load += new System.EventHandler(this.ImpreEvaServ_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVEvaServ;
    }
}