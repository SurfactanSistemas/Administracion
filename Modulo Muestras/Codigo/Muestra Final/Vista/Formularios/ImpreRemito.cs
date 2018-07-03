using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
        private string[] WDatosRemitos;

        private string[,] HojasDeSeguridad;
        private const string ORIGEN_HOJA_SEGURIDAD = "W:\\impresion pdf\\fds\\fds#NOMBREPDF#.pdf";
        private const string DESTINO_HOJA_SEGURIDAD = "C:\\pdfprint\\fds#NOMBREPDF#.pdf";



        public ImpreRemito(DataTable DT, string DirEnt, string CodClient, string DirClient, string LocalidadClient, string Cuit, string cliente, string[,] FDSs, string[] wDatosRemito)
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
            HojasDeSeguridad = FDSs;
            WDatosRemitos = wDatosRemito;
        }

        public ImpreRemito(DataTable DT, string DirEnt, string CodClient, string DirClient, string LocalidadClient, string Cuit, string cliente, string[] wDatosRemito)
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
            WDatosRemitos = wDatosRemito;
        }

        private void ImpreRemito_Load(object sender, EventArgs e)
        {
            DSRemito1 Ds = new DSRemito1();
            Ds.Tables["DataTable1"].Rows.Add
                (cliente, DirClient, LocalidadClient, DirEnt, CodClient, Cuit);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                DataRow dr = DT.Rows[i];
                Ds.Tables["DataTable" + (i+2).ToString().Trim()].Rows.Add
                    (dr[0].ToString(), dr[1].ToString().Trim(), dr["Peligroso"].ToString(), dr["PeligrosoII"].ToString());
            }

            Ds.Tables["Detalles"].Rows.Add
                    (WDatosRemitos[0], WDatosRemitos[1], WDatosRemitos[2], WDatosRemitos[3], WDatosRemitos[4]);

            if (HojasDeSeguridad != null)
            {
                if (HojasDeSeguridad.GetLength(0) > 0)
                {
                    if (HojasDeSeguridad[0, 0].Trim() != "")
                    {
                        if (MessageBox.Show("¿Quiere reimprimir las hojas de seguridad?","", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                            ImprimirHojasDSeguridad(HojasDeSeguridad);
                
                        }

                    }
                }
            }

            CRVRemito.Visible = true;
            ImpRemito2 RImp = new ImpRemito2();
            RImp.SetDataSource(Ds);
            CRVRemito.ReportSource = RImp;
            
            
        }

        private void ImprimirHojasDSeguridad(string[,] HojasDeSeguridad)
        {
            try
            {

                // Avisamos para que puedan sacar las hojas de remitos.
                MessageBox.Show("Se van a imprimir las hojas de seguridad. Por favor, coloque hojas A4 para las misma.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string desc = "";
                string cod = "";

                // Borramos el directorio en caso de que exista.
                if (Directory.Exists(@"C:\pdfprint"))
                {

                    Directory.Delete(@"C:\pdfprint", true);

                }

                // Creamos el directorio donde alojaremos los pdf a imprimir.
                Directory.CreateDirectory(@"C:\pdfprint");

                for (int i = 0; i < HojasDeSeguridad.GetLength(0); i++)
                {
                    // Formateamos la descripcion y el codigo segun sea el tipo.
                    desc = HojasDeSeguridad[i, 0].Trim();
                    cod = HojasDeSeguridad[i, 1].Trim();

                    // Eliminamos los espacios y "/" del nombre del Producto.
                    desc = desc.Replace(" ", "").Replace("/", "");

                    string WRutaFds = "";
                    string nom = "";

                    //if (cod.StartsWith("PT") || cod.StartsWith("CO"))
                    if (!cod.StartsWith("DY"))
                    {
                        // Eliminamos los "-".
                        cod = cod.Replace("-", "");

                        string temp = cod.Replace("PT", "");

                        // Los 25000 (Farma), se guardan con el formato FDS25000100-NOMBREDELPRODUCTO PARTIDA
                        if (temp.StartsWith("25"))
                        {
                            // Buscamos el archivo que coincida con el codigo de producto.
                            foreach (string file in Directory.GetFiles(@"w:\impresion pdf\fds"))
                            {
                                if (file.Contains(temp))
                                {
                                    WRutaFds = file;
                                    break;
                                }
                            }
                        }
                        else // En los demas casos, siguen el formato normal FDSNOMBREPRODUCTO06570100
                        {
                            WRutaFds = ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", desc + cod.Substring(2, cod.Length - 2));
                        }

                    }
                    else // Los DY, siguen el siguiente formato FDSDY-600-101
                    {
                        string[] ZCod = cod.Split('-');

                        // Eliminamos los ceros de mas que pudiesen estar presentes en el codigo intermedio. EJ: DY-00302-100 -> DY-302-100.
                        ZCod[1] = int.Parse(ZCod[1]).ToString();

                        cod = string.Join("-", ZCod);

                        WRutaFds = ORIGEN_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", cod);
                    }

                    if (File.Exists(WRutaFds))
                    {
                        nom = Path.GetFileNameWithoutExtension(WRutaFds);

                        File.Copy(WRutaFds, DESTINO_HOJA_SEGURIDAD.Replace("#NOMBREPDF#", nom));

                    }
                    else
                    {
                        // Notificamos al usuario la NO existencia de alguna Hoja de Seguridad.
                        MessageBox.Show("¡No existe FDS del " + HojasDeSeguridad[i, 0].Trim() + " (" + HojasDeSeguridad[i, 1].Trim() + ")!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Imprimimos las hojas guardadas.

                // Recorremos e imprimimos los archivos copiados a la carpeta "pdfprint"
                foreach (string file in Directory.GetFiles(@"C:\pdfprint"))
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = file //put the correct path here
                    };
                    p.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
