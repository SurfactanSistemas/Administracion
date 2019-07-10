using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Modulo_Capacitacion.Properties;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;

namespace Modulo_Capacitacion.Novedades
{
    public partial class AgregarArchivosPlanillaCapacitacion : Form
    {
        private readonly string WPlanilla;
        private readonly string WMP;
        private readonly string WReq;
        private readonly String WPath;

        private const String EXTENSIONES_PERMITIDAS = "*.bmp|*.png|*.jpg|*.jpeg|*.pdf|*.doc|*.docx|*.xls|*.xlsx";

        public AgregarArchivosPlanillaCapacitacion(string Planilla)
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            WPlanilla = Planilla.PadLeft(6, '0');

            WPath = ConfigurationManager.AppSettings["PATH_DOCS_PLANILLAS_CAPACITACION_MP"] + WPlanilla;
        }

        private void AgregarArchivosPlanillaCapacitacion_Load(object sender, EventArgs e)
        {

            // 
            // Creamos la carpeta que contendrá los archivos en caso de que no se encuentre creada ya.
            // 
            Directory.CreateDirectory(WPath);

            _CargarArchivosRelacionados();
        }

        // 
        // Rutinas de Archivos.
        // 
        private void dgvArchivos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            {
                var withBlock = dgvArchivos.Rows[e.RowIndex];
                if (withBlock.Cells["PathArchivo"].Value != null)
                {
                    try
                    {
                        Process.Start(withBlock.Cells["PathArchivo"].Value.ToString(), "f");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void dgvArchivos_DragEnter(object sender, DragEventArgs e)
        {
            _PermitirDrag(e);
        }

        private void _PermitirDrag(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void _ProcesarDragDeArchivo(DragEventArgs e)
        {
            string[] archivos = (string[]) e.Data.GetData(DataFormats.FileDrop);

            _SubirArchvios(archivos);
        }

        private void _SubirArchvios(string[] archivos)
        {
            var WDestino = "";
            var WCantCorrectas = 0;

            if (archivos.Length == 0)
                return;

            foreach (var archivo in archivos)
            {
                if (File.Exists(archivo))
                {
                    string extension = Path.GetExtension(archivo);

                    if (extension != null && EXTENSIONES_PERMITIDAS.Contains(extension.ToLower()))
                    {
                        WDestino = WPath + @"\" + Path.GetFileName(archivo);

                        try
                        {
                            if (!File.Exists(WDestino))
                            {
                                File.Copy(archivo, WDestino);
                                WCantCorrectas += 1;
                            }
                            else if (
                                MessageBox.Show(
                                    "El Archivo " + Path.GetFileName(archivo) +
                                    ", ya existe en la carpeta. ¿Desea sobreescribir el archivo existente?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                File.Copy(archivo, WDestino, true);
                                WCantCorrectas += 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                }
            }

            if (WCantCorrectas > 0)
                MessageBox.Show("Se subieron correctamente " + WCantCorrectas + " Archivo(s)");

            _CargarArchivosRelacionados();
        }

        private void dgvArchivos_DragDrop(object sender, DragEventArgs e)
        {
            _ProcesarDragDeArchivo(e);
        }

        private void _CargarArchivosRelacionados()
        {
            FileInfo InfoArchivo;

            dgvArchivos.Rows.Clear();

            // Recorremos unicamente aquellos archivos que tengan una extensión que esté entre las permitidas por la aplicación.
            foreach (
                string WNombreArchivo in
                    Directory.GetFiles(WPath)
                        .Where(s => EXTENSIONES_PERMITIDAS.Contains(Path.GetExtension(s).ToLower())))
            {
                InfoArchivo = FileSystem.GetFileInfo(WNombreArchivo);

                {
                    FileInfo withBlock = InfoArchivo;
                    string Ext = withBlock.Extension;
                    dgvArchivos.Rows.Add(withBlock.CreationTime.ToString("dd/MM/yyyy"), Strings.UCase(withBlock.Name),
                        _ObtenerIconoSegunTipoArchivo(Ext), withBlock.FullName);
                }
            }
        }

        private object _ObtenerIconoSegunTipoArchivo(string extension)
        {
            object Wicono;

            switch (Strings.UCase(extension))
            {
                case ".DOC":
                case ".DOCX":
                {
                    Wicono = Resources.Word_icon;
                    break;
                }

                case ".XLS":
                case ".XLSX":
                case ".XLSM":
                {
                    Wicono = Resources.Excel_icon;
                    break;
                }

                case ".PDF":
                {
                    Wicono = Resources.pdf_icon;
                    break;
                }

                case ".JPG":
                case ".JPEG":
                case ".BMP":
                case ".ICO":
                case ".PNG":
                {
                    Wicono = Resources.imagen_icono;
                    break;
                }

                case ".TXT":
                {
                    Wicono = Resources.txt_icono;
                    break;
                }

                default:
                {
                    Wicono = Resources.archivo_default;
                    break;
                }
            }

            return Wicono;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    var withBlock = openFileDialog1;
                    withBlock.Filter = "Imágenes (bmp, jpg, png) | " +
                                       string.Join(";", EXTENSIONES_PERMITIDAS.Split('|'));
                    if (withBlock.ShowDialog() == DialogResult.OK)
                    {
                        string[] WArchivos = withBlock.FileNames;

                        if (WArchivos.Length > 0)
                            _SubirArchvios(WArchivos);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArchivos.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro de querer eliminar todos los archivos indicados?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    foreach (DataGridViewRow row in dgvArchivos.SelectedRows)
                    {
                        {
                            var withBlock = row;
                            if (Helper.OrDefault(withBlock.Cells["PathArchivo"].Value, "").ToString() == "")
                                continue;

                            File.Delete(withBlock.Cells["PathArchivo"].Value.ToString());
                        }
                    }

                    _CargarArchivosRelacionados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}