using System.ComponentModel;
using CrystalDecisions.Windows.Forms;

namespace Vista
{
    partial class ImpreEtiquetChic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.CRVEtiquetas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRVEtiquetas
            // 
            this.CRVEtiquetas.ActiveViewIndex = -1;
            this.CRVEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVEtiquetas.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVEtiquetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVEtiquetas.Location = new System.Drawing.Point(0, 0);
            this.CRVEtiquetas.Name = "CRVEtiquetas";
            this.CRVEtiquetas.ShowCloseButton = false;
            this.CRVEtiquetas.ShowGotoPageButton = false;
            this.CRVEtiquetas.ShowGroupTreeButton = false;
            this.CRVEtiquetas.ShowLogo = false;
            this.CRVEtiquetas.ShowParameterPanelButton = false;
            this.CRVEtiquetas.ShowRefreshButton = false;
            this.CRVEtiquetas.Size = new System.Drawing.Size(784, 562);
            this.CRVEtiquetas.TabIndex = 0;
            this.CRVEtiquetas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CRVEtiquetas.Load += new System.EventHandler(this.CRVEtiquetas_Load);
            // 
            // ImpreEtiquetChic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.CRVEtiquetas);
            this.Name = "ImpreEtiquetChic";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImpreEtiquetChic";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalReportViewer CRVEtiquetas;
    }
}