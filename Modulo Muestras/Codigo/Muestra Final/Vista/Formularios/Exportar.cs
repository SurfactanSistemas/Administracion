using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Negocio;

namespace Vista
{
    public partial class Exportar : Form
    {
        ClaseExcel ce = new ClaseExcel();
        private DataTable dt;
        private string path = "";
        private string modified = "";

        public Exportar()
        {
            InitializeComponent();
        }

        public Exportar(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void Exportar_Load(object sender, EventArgs e)
        {
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    
                {
                    case DriveType.CDRom:
                        driveImage = 2;
                        break;
                    case DriveType.Fixed:
                        driveImage = 0;
                        break;

                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    case DriveType.Removable:
                        driveImage = 3;
                        break;
                    default:
                        driveImage = 1;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                TV_Directorio.Nodes.Add(node);
            }
        }

        private void TV_Directorio_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 1, 1);
                        try
                        {
                            node.Tag = dir;
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void TV_Directorio_AfterSelect(object sender, TreeViewEventArgs e)
        {
                TreeNode CurrentNode = e.Node;
                string fullpath = CurrentNode.FullPath;
                modified = fullpath.Insert(1, ":");          
        }

        private void BTAceptar_Click(object sender, EventArgs e)
        {
            if (TBNombreExport.Text == "") MessageBox.Show("¡No se ha ingresado el nombre del archivo!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (modified == "") MessageBox.Show("Se debe seleccionar la carpeta donde guardar el archivo excel", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                modified += "\\" + TBNombreExport.Text;
                path = modified;    

                ce.CrearExcel(dt, path);
                Close();
            }
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
