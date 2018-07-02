namespace HojaRuta.Listados.VencimientoChoferes
{
    partial class ImpreVencChofer
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
            this.CRVVencChofer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVVencChofer
            // 
            this.CRVVencChofer.ActiveViewIndex = -1;
            this.CRVVencChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVVencChofer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVVencChofer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVVencChofer.Location = new System.Drawing.Point(0, 0);
            this.CRVVencChofer.Name = "CRVVencChofer";
            this.CRVVencChofer.ShowCloseButton = false;
            this.CRVVencChofer.ShowGotoPageButton = false;
            this.CRVVencChofer.ShowGroupTreeButton = false;
            this.CRVVencChofer.ShowLogo = false;
            this.CRVVencChofer.ShowParameterPanelButton = false;
            this.CRVVencChofer.ShowRefreshButton = false;
            this.CRVVencChofer.Size = new System.Drawing.Size(784, 562);
            this.CRVVencChofer.TabIndex = 0;
            this.CRVVencChofer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreVencChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVVencChofer);
            this.Name = "ImpreVencChofer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImpreVencChofer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVVencChofer;
    }
}