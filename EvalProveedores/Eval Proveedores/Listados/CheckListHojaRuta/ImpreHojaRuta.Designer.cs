namespace Eval_Proveedores.Listados.CheckListHojaRuta
{
    partial class ImpreHojaRuta
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
            this.CRVHojaRuta = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVHojaRuta
            // 
            this.CRVHojaRuta.ActiveViewIndex = -1;
            this.CRVHojaRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVHojaRuta.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVHojaRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVHojaRuta.Location = new System.Drawing.Point(0, 0);
            this.CRVHojaRuta.Name = "CRVHojaRuta";
            this.CRVHojaRuta.ShowCloseButton = false;
            this.CRVHojaRuta.ShowGotoPageButton = false;
            this.CRVHojaRuta.ShowGroupTreeButton = false;
            this.CRVHojaRuta.ShowLogo = false;
            this.CRVHojaRuta.ShowParameterPanelButton = false;
            this.CRVHojaRuta.ShowRefreshButton = false;
            this.CRVHojaRuta.Size = new System.Drawing.Size(784, 562);
            this.CRVHojaRuta.TabIndex = 1;
            this.CRVHojaRuta.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ImpreHojaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVHojaRuta);
            this.Name = "ImpreHojaRuta";
            this.Load += new System.EventHandler(this.ImpreHojaRuta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVHojaRuta;
    }
}