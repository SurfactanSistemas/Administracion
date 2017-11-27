using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Vista
{
    public partial class ImpreRemito : Form
    {
        private DataTable DT;
        private string DirEnt;
        private string Datos;
        private string CodClient;
        private string DirClient;
        private string LocalidadClient;
        private string Cuit;
        private string cliente;

        private string[,] HojasDeSeguridad;
        private const string ORIGEN_HOJA_SEGURIDAD = "W:\\impresion pdf\\fds\\fds#NOMBREPDF#.pdf";
        private const string DESTINO_HOJA_SEGURIDAD = "C:\\pdfprint\\fds#NOMBREPDF#.pdf";



        public ImpreRemito(DataTable DT, string DirEnt, string CodClient, string DirClient, string LocalidadClient, string Cuit, string cliente, string[,] FDSs)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.DT = DT;
            this.DirEnt = DirEnt;
            this.CodClient = CodClient;
            this.DirClient = DirClient;
            this.LocalidadClient = LocalidadClient;
            this.Cuit = Cuit;
            this.cliente = cliente;
            this.HojasDeSeguridad = FDSs;
        }

        public ImpreRemito(DataTable DT, string DirEnt, string CodClient, string DirClient, string LocalidadClient, string Cuit, string cliente)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.DT = DT;
            this.DirEnt = DirEnt;
            this.CodClient = CodClient;
            this.DirClient = DirClient;
            this.LocalidadClient = LocalidadClient;
            this.Cuit = Cuit;
            this.cliente = cliente;
        }

        private void ImpreRemito_Load(object sender, EventArgs e)
        {
            DSRemito1 Ds = new DSRemito1();
            Ds.Tables[0].Rows.Add
                (new object[]
                {
                    cliente,
                    DirClient,
                    LocalidadClient,
                    DirEnt,
                    CodClient,
                    Cuit,

                }
                );

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                DataRow dr = DT.Rows[i];
                Ds.Tables[i+1].Rows.Add
                    (new object[]
                    {
                        dr[0].ToString(),
                        dr[1].ToString() + "KG Netos",
                        dr["Peligroso"].ToString(),
                        dr["PeligrosoII"].ToString(),
                    }
                    );
            }

            if (this.HojasDeSeguridad != null)
            {
                if (this.HojasDeSeguridad.GetLength(0) > 0)
                {
                    if (this.HojasDeSeguridad[0, 0].ToString().Trim() != "")
                    {
                        if (MessageBox.Show("¿Quiere reimprimir las hojas de seguridad?","", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                            this.ImprimirHojasDSeguridad(this.HojasDeSeguridad);
                
                        }

                    }
                }
            }

            CRVRemito.Visible = true;
            ImpRemito RImp = new ImpRemito();
            RImp.SetDataSource(Ds);
            CRVRemito.ReportSource = RImp;
            
            
        }

        private void ImprimirHojasDSeguridad(string[,] HojasDeSeguridad)
        {

            // Avisamos para que puedan sacar las hojas de remitos.
            MessageBox.Show("Se van a imprimir las hojas de seguridad. Por favor, coloque hojas A4 para las misma.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string desc = "";
            string cod = "";

            // Borramos el directorio en caso de que exista.
            if (System.IO.Directory.Exists(@"C:\pdfprint"))
            {

                System.IO.Directory.Delete(@"C:\pdfprint", true);

            }

            // Creamos el directorio donde alojaremos los pdf a imprimir.
            System.IO.Directory.CreateDirectory(@"C:\pdfprint");

            for (int i = 0; i < HojasDeSeguridad.GetLength(0); i++)
            {
                // Formateamos la descripcion y el codigo segun sea el tipo.
                desc = HojasDeSeguridad[i, 0].Trim();
                cod = HojasDeSeguridad[i, 1].Trim();

                // Eliminamos los espacios y "/" del nombre del Producto.
                desc = desc.Replace(" ", "").Replace("/", "");

                if (cod.StartsWith("PT") || cod.StartsWith("CO"))
                {
                    // Eliminamos los "-" y el prefijo "PT" del Código del Producto.
                    cod = cod.Replace("-", "").Replace("PT", "");
                }
                else
                {
                    string[] ZCod = cod.Split('-');

                    // Eliminamos los ceros de mas que pudiesen estar presentes en el codigo intermedio. EJ: DY-00302-100 -> DY-302-100.
                    ZCod[1] = int.Parse(ZCod[1]).ToString();

                    cod = string.Join("-", ZCod);
                }

                string nom = (cod.StartsWith("PT")) ? desc + cod : cod;

                if (System.IO.File.Exists(ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", nom)))
                {

                    System.IO.File.Copy(ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", nom), DESTINO_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", nom));

                }
                else
                {
                    // Notificamos al usuario la NO existencia de alguna Hoja de Seguridad.
                    MessageBox.Show("¡No existe FDS del " + HojasDeSeguridad[i, 0].Trim() + " (" + HojasDeSeguridad[i, 1].Trim() + ")!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Imprimimos las hojas guardadas.

            // Recorremos e imprimimos los archivos copiados a la carpeta "pdfprint"
            foreach (string file in System.IO.Directory.GetFiles(@"C:\pdfprint"))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = file //put the correct path here
                };
                p.Start();
            }

        }


    }
}
