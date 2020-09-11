﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eval_Proveedores.Listados.CheckListRecepcion
{
    public partial class ImpreInforme : Form
    {
        private DataTable dtInforme;
        private string Tipo;

        public ImpreInforme()
        {
            InitializeComponent();
        }

        public ImpreInforme(DataTable dtInforme)
        {
            // TODO: Complete member initialization
            this.dtInforme = dtInforme;
            InitializeComponent();
        }

        public ImpreInforme(DataTable dtInforme, string Tipo)
        {
            // TODO: Complete member initialization
            this.dtInforme = dtInforme;
            this.Tipo = Tipo;
            InitializeComponent();
        }
        
        private void ImpreInforme_Load(object sender, EventArgs e)
        {
            DSInforme Ds = new DSInforme();

            int filas = dtInforme.Rows.Count;

            for (int i = filas - 1; i > -1; i--)
            {
                DataRow dr = dtInforme.Rows[i];
                Ds.Tables[0].Rows.Add
                (new object[]
                {
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    dr[6].ToString(),
                    dr[7].ToString(),
                    dr[8].ToString(),
                    dr[9].ToString(),
                    dr[10].ToString(),
                    dr[11].ToString(),
                    dr[12].ToString(),
                    dr[13].ToString(),
                    dr[14].ToString(),
                    dr[15].ToString(),
                    dr[16].ToString(),
                    dr[17].ToString(),
                    
                    

                }

                );
            }

            if (Tipo == "Pantalla")
            {
                //Hago visible el report viewer
                CRVInforme.Visible = true;


                //Instancio el ReportImpre creado
                ReportInforme RImpre = new ReportInforme();


                //Cargo el reportImpre con el dataset DS
                RImpre.SetDataSource(Ds);

                //Cargo el report viewer con el ReportImp
                CRVInforme.ReportSource = RImpre;
            }
            else
            {
                //Instancio el ReportImpre creado
                ReportInforme RImpre = new ReportInforme();

                //Cargo el reportImpre con el dataset DS
                RImpre.SetDataSource(Ds);

                RImpre.PrintToPrinter(1, true, 1, 999);
                Close();
            }
            
            
        }

        private void CRVInforme_Load(object sender, EventArgs e)
        {

        }
    }
}
