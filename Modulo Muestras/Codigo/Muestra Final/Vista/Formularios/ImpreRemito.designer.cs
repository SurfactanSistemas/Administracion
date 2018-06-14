namespace Vista
{
    partial class ImpreRemito
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
            this.CRVRemito = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVRemito
            // 
            this.CRVRemito.ActiveViewIndex = -1;
            this.CRVRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVRemito.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVRemito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVRemito.Location = new System.Drawing.Point(0, 0);
            this.CRVRemito.Name = "CRVRemito";
            this.CRVRemito.ShowCloseButton = false;
            this.CRVRemito.ShowGotoPageButton = false;
            this.CRVRemito.ShowGroupTreeButton = false;
            this.CRVRemito.ShowLogo = false;
            this.CRVRemito.ShowParameterPanelButton = false;
            this.CRVRemito.ShowRefreshButton = false;
            this.CRVRemito.Size = new System.Drawing.Size(784, 562);
            this.CRVRemito.TabIndex = 0;
            this.CRVRemito.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVRemito);
            this.Name = "ImpreRemito";
            this.Text = "ImpreRemito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImpreRemito_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVRemito;
    }
}