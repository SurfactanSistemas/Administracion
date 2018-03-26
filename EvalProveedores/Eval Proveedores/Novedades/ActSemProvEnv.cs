using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica_Negocio;
using Negocio;

namespace Eval_Proveedores.Novedades
{
    public partial class ActSemProvEnv : Form
    {
        ProveedorBOL PBOL = new ProveedorBOL();
        DataTable dtEvaluacion = new DataTable();
        DataTable dtInformeMuestra = new DataTable();
        DataTable dtInforme = new DataTable();
        EvalSemestralBOL ESBOL = new EvalSemestralBOL();
        DataTable dtInformeDetalle;
        int OrdFechaDesde;
        int ordFechaHAsta;
        bool Encontrado = false;
        bool InformeMuestraEncontrado = false;
        int FilaEncontradaInformeMuestra;
        int Items1;
        int Certfic;
        DataRow filaEval;
        DataRow filaInformeMuestra;
        int FilaEncontrada;
        Proveedor P = new Proveedor();
        Proveedor Prove = new Proveedor();


        public ActSemProvEnv()
        {
            InitializeComponent();
        }

        private void ActSemProvEnv_Load(object sender, EventArgs e)
        {
            CargarDtEvaluacion();
            CargardtInformeMuestra();

            DGV_EvalSemProve.Visible = false;

            LB_Titulo.Visible = false;
        }

        private void CargarDtEvaluacion()
        {
            dtEvaluacion.Columns.Add("CodProve", typeof(string));
            dtEvaluacion.Columns.Add("Aprobado", typeof(string));

            dtEvaluacion.Columns.Add("Certificado", typeof(string));
            dtEvaluacion.Columns.Add("Enviado", typeof(string));
            dtEvaluacion.Columns.Add("Desviado", typeof(int));
            dtEvaluacion.Columns.Add("Rechazado", typeof(int));
            dtEvaluacion.Columns.Add("Atraso", typeof(int));
            //dtEvaluacion.Columns.Add("Fecha", typeof(string));
            //dtEvaluacion.Columns.Add("Liberada", typeof(int));
            //dtEvaluacion.Columns.Add("Partida", typeof(int));
            dtEvaluacion.Columns.Add("Clave", typeof(string));
            
        }

        private void CargardtInformeMuestra()
        {
            dtInformeMuestra.Columns.Add("CodProve", typeof(string));
            dtInformeMuestra.Columns.Add("DescProve", typeof(string));
            dtInformeMuestra.Columns.Add("Items", typeof(string));
            dtInformeMuestra.Columns.Add("Aprobado", typeof(int));
            dtInformeMuestra.Columns.Add("Desviado", typeof(int));
            dtInformeMuestra.Columns.Add("Rechazado", typeof(int));
            dtInformeMuestra.Columns.Add("Certificado", typeof(int));
            dtInformeMuestra.Columns.Add("Enviado", typeof(int));
            //dtInformeMuestra.Columns.Add("PorcCert", typeof(double));
            //dtInformeMuestra.Columns.Add("PorcEnv", typeof(double));
            //dtInformeMuestra.Columns.Add("PorcTotal", typeof(double));
            dtInformeMuestra.Columns.Add("Atraso", typeof(int));
            dtInformeMuestra.Columns.Add("Fecha", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria1", typeof(string));
            dtInformeMuestra.Columns.Add("Categoria2", typeof(string));
            dtInformeMuestra.Columns.Add("CatI", typeof(int));
            dtInformeMuestra.Columns.Add("CatII", typeof(int));
        }

        private void BT_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string Desde = TB_Desde.Text.Substring(6, 4) + TB_Desde.Text.Substring(3, 2) + TB_Desde.Text.Substring(0, 2);
                string Hasta = TB_Hasta.Text.Substring(6, 4) + TB_Hasta.Text.Substring(3, 2) + TB_Hasta.Text.Substring(0, 2);


                if (Desde == "") throw new Exception("Se debe ingresar la fecha Desde donde desea listar");
                if (Desde == "") throw new Exception("Se debe ingresar la fecha Hasta donde desea listar");

                if (CB_TipoEva.Text == "") throw new Exception("Se debe elegir el tipo de evaluación");

                dtEvaluacion.Clear();
                dtInformeMuestra.Clear();

                OrdFechaDesde = int.Parse(Desde);
                ordFechaHAsta = int.Parse(Hasta);

                //TIPO D EPROVEEDOR
                int Tipo = 2;

                dtInforme = ESBOL.ListaInforme(OrdFechaDesde, ordFechaHAsta, "SurfactanSA", Tipo);
                CargarInforme(dtInforme);

                dtInforme = ESBOL.ListaInforme(OrdFechaDesde, ordFechaHAsta, "Surfactan_V", Tipo);
                CargarInforme(dtInforme);

                dtInforme = ESBOL.ListaInforme(OrdFechaDesde, ordFechaHAsta, "Surfactan_II", Tipo);
                CargarInforme(dtInforme);

                 CargarMuestraInforme();

                 DGV_EvalSemProve.DataSource = dtInformeMuestra;

                 //CONSULTO QUE TIPO DE EVALUACION SE DESEA PARA MOSTRAR LOS CAMPOS
                 if (CB_TipoEva.Text == "CALIDAD")
                 {


                     DGV_EvalSemProve.Columns["EvaCal"].Visible = true;

                     DGV_EvalSemProve.Columns["EvaEnt"].Visible = false;

                     DGV_EvalSemProve.Columns["Cate1"].Visible = true;

                     DGV_EvalSemProve.Columns["Cate2"].Visible = false;
                 }

                 if (CB_TipoEva.Text == "ENTREGA")
                 {
                     DGV_EvalSemProve.Columns["EvaCal"].Visible = false;

                     DGV_EvalSemProve.Columns["EvaEnt"].Visible = true;

                     DGV_EvalSemProve.Columns["Cate1"].Visible = false;

                     DGV_EvalSemProve.Columns["Cate2"].Visible = true;
                 }


                 DGV_EvalSemProve.Visible = true;

                 LB_Titulo.Visible = true;


            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void CargarInforme(DataTable dtInforme)
        {
             //RECORRO LA LISTA DTINFORME
            for (int i = 0; i < dtInforme.Rows.Count; i++)
            {
                DataRow fila = dtInforme.Rows[i];
                int contador = 0;
                int filaGrabar = 0;
                Encontrado = false;
                filaEval = dtEvaluacion.NewRow();

                //CONSULTO SI LA TABLA EVALUACION TIENE FILAS
                if (dtEvaluacion.Rows.Count > 0)
                {
                   
                        //RECORRO LA LISTA GUARDADA DE EVALUACIONES PARA VER SI SE ENCUENTRA LA CLAVE.
                        for (int j = 0; j < dtEvaluacion.Rows.Count; j++)
                        {
                            DataRow filaComp = dtEvaluacion.Rows[j];

                            if (filaComp["Clave"].ToString() == fila[3].ToString())
                            {
                                //SI ENCUENTRO LA CLAVE QUIERE DECIR QUE YA SE EVALUO
                                Encontrado = true;
                                FilaEncontrada = j;
                            }
                        }
                    
                }





                //SI LA CLAVE NO ESTA GUARDAD EN LA TABLE EVALUACION
                //CONTROLO ATRASO, CERTIFICADO Y ENVIADO
                if (Encontrado == false)
                {
                    //AGREGO LA CLAVE A LA FILA PARA COMPRARA SI EXISTE MAS DE UN LAUDO PARA EL MISMO ITEM
                    filaEval["Clave"] = fila[3].ToString();

                    //AGREGO EL PROVEEDOR PARA SABER CUANTOS ITEMS TIENE.
                    filaEval["CodProve"] = fila[11].ToString();

                    /*
                    

                    

                    //CARGO LA FECHA DE EVALUACION DEL PROVEEDOR
                    filaEval["Fecha"] = fila[21].ToString();
                     * */

                    //COMPRUEBO QUE LA FECHA2 DE LA ORDEN SEA MENOR QUE LA FECHA DEL INFORME
                    int Fecha;
                    int Fecha2;

                    int.TryParse(fila[2].ToString(), out Fecha);
                    int.TryParse(fila[10].ToString(), out Fecha2);


                    if (Fecha > Fecha2)
                    {
                        filaEval["Atraso"] = 1;
                    }


                    //COMPRUEBO QUE CERTIFICADO SEA IGUAL A 1
                    if (fila[4].ToString() == "1")
                    {
                        filaEval["Certificado"] = 1;
                    }

                    //COMPRUEBO QUE ESTADO IGUAL A 1

                    if (fila[5].ToString() == "1")
                    {
                        filaEval["Enviado"] = 1;
                    }
                }



                //COMPRUEBO SI LAUDO ES DISTINTO DE NULO, YA QUE LOS ENVASES NO SE LES INGRESA LAUDO
                if (fila[15].ToString() != "")
                {

                    int liberada;
                    int liberadaant;
                    int devueltaant;
                    int Devuelta;
                    int Cantidad;
                    int CantidadGuardad;

                    int Laudo = int.Parse(fila[15].ToString());

                    int.TryParse(fila[13].ToString(), out liberada);
                    int.TryParse(fila[14].ToString(), out liberadaant);
                    int.TryParse(fila[17].ToString(), out devueltaant);
                    int.TryParse(fila[16].ToString(), out Devuelta);
                    int.TryParse(fila[7].ToString(), out Cantidad);
                    //int.TryParse(filaEval["CantidadGuardada"].ToString(), out CantidadGuardad);




                    //COMPRUEBO QUE MARCA TENGA X
                    if (fila[12].ToString() == "X")
                    {





                        //CONSULTO SI LIBERADA ES > 0
                        if (liberadaant > 0)
                        {
                            //CONSULTA SI FUE APROBADA POR DESVIO
                            if ((Laudo >= 190000 && Laudo <= 194999) || (Laudo >= 990000 && Laudo <= 994999) || (Laudo >= 290000 && Laudo <= 294999) ||
                                (Laudo >= 390000 && Laudo <= 394999) || (Laudo >= 490000 && Laudo <= 494999) || (Laudo >= 590000 && Laudo <= 594999) ||
                                (Laudo >= 690000 && Laudo <= 694999) || (Laudo >= 790000 && Laudo <= 794999) || (Laudo >= 890000 && Laudo <= 894999))
                            {
                                if (Encontrado == true)
                                {
                                    dtEvaluacion.Rows[FilaEncontrada]["Desviado"] = 1;
                                }
                                else
                                {
                                    filaEval["Desviado"] = 1;
                                }
                            }
                            else
                            {
                                if (Encontrado == true)
                                {
                                    dtEvaluacion.Rows[FilaEncontrada]["Aprobado"] = 1;
                                }
                                else
                                {
                                    filaEval["Aprobado"] = 1;
                                }
                            }
                        }
                        if (devueltaant > 0)
                        {
                            if (Encontrado == true)
                            {
                                dtEvaluacion.Rows[FilaEncontrada]["Rechazado"] = 1;
                            }
                            else
                            {
                                filaEval["Rechazado"] = 1;
                            }
                        }










                    }
                    //SINO TIENE MARCA
                    else
                    {
                        //CONSULTO SI LIBERADA ES > 0
                        if (liberada > 0)
                        {
                            //CONSULTA SI FUE APROBADA POR DESVIO
                            if ((Laudo >= 190000 && Laudo <= 194999) || (Laudo >= 990000 && Laudo <= 994999) || (Laudo >= 290000 && Laudo <= 294999) ||
                                (Laudo >= 390000 && Laudo <= 394999) || (Laudo >= 490000 && Laudo <= 494999) || (Laudo >= 590000 && Laudo <= 594999) ||
                                (Laudo >= 690000 && Laudo <= 694999) || (Laudo >= 790000 && Laudo <= 794999) || (Laudo >= 890000 && Laudo <= 894999))
                            {
                                if (Encontrado == true)
                                {
                                    dtEvaluacion.Rows[FilaEncontrada]["Desviado"] = 1;
                                }
                                else
                                {
                                    filaEval["Desviado"] = 1;
                                }
                            }
                            else
                            {
                                if (Encontrado == true)
                                {
                                    dtEvaluacion.Rows[FilaEncontrada]["Aprobado"] = 1;
                                }
                                else
                                {
                                    filaEval["Aprobado"] = 1;
                                }
                            }
                        }
                        if (Devuelta > 0)
                        {
                            if (Encontrado == true)
                            {
                                dtEvaluacion.Rows[FilaEncontrada]["Rechazado"] = 1;
                            }
                            else
                            {
                                filaEval["Rechazado"] = 1;
                            }
                        }
                    }
                }





                if (Encontrado == false)
                {
                    dtEvaluacion.Rows.Add(filaEval);
                }










            }
        }



        private void CargarMuestraInforme()
        {
            for (int i = 0; i < dtEvaluacion.Rows.Count; i++)
            {
                DataRow fila = dtEvaluacion.Rows[i];
                InformeMuestraEncontrado = false;
                filaInformeMuestra = dtInformeMuestra.NewRow();


                for (int j = 0; j < dtInformeMuestra.Rows.Count; j++)
                {
                    DataRow filamuestra = dtInformeMuestra.Rows[j];

                    if (fila[0].ToString() == filamuestra[0].ToString())
                    {
                        InformeMuestraEncontrado = true;
                        FilaEncontradaInformeMuestra = j;
                        //dtInformeMuestra.Rows[j][1] = +1;


                    }
                }


                if (InformeMuestraEncontrado == false)
                {
                    filaInformeMuestra["CodProve"] = fila[0].ToString();

                    P = PBOL.Find(fila[0].ToString());
                    filaInformeMuestra["DescProve"] = P.Descripcion;

                    //CARGAR CALIDAD DEL PROVEEDOR
                    int Calidad = P.Categoria1;
                    filaInformeMuestra["CatI"] = Calidad;
                    CargarCalidad(Calidad);

                    //CARGAR ENTREGA DEL PROVEEDOR
                    int Entrega = P.Categoria2;
                    filaInformeMuestra["CatII"] = Entrega;
                    CargarEntrega(Entrega);


                    filaInformeMuestra["Fecha"] = P.FechaCat;

                }

                if (InformeMuestraEncontrado == true)
                {
                    int CantItems;

                    int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Items"].ToString(), out CantItems);

                    dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Items"] = CantItems + 1;

                }
                else
                {
                    filaInformeMuestra["Items"] = 1;
                }




                if (fila[3].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantAprobado;
                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Aprobado"].ToString(), out CantAprobado);

                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Aprobado"] = CantAprobado + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Aprobado"] = 1;
                    }

                }

                if (fila[4].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantDesv;
                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Desviado"].ToString(), out CantDesv);


                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Desviado"] = CantDesv + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Desviado"] = 1;
                    }

                }

                if (fila[5].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantRechazo;
                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Rechazado"].ToString(), out CantRechazo);


                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Rechazado"] = CantRechazo + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Rechazado"] = 1;
                    }

                }

                if (fila[2].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantCert;

                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Certificado"].ToString(), out CantCert);
                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Certificado"] = CantCert + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Certificado"] = 1;
                    }

                }

                if (fila[3].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantEnviado;
                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Enviado"].ToString(), out CantEnviado);
                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Enviado"] = CantEnviado + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Enviado"] = 1;
                    }

                }








                double PorcCert;
                
                /*
                if (InformeMuestraEncontrado == true)
                {
                    int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Certificado"].ToString(), out Certfic);
                    Items1 = int.Parse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Items"].ToString());
                    PorcCert = (Certfic * 100) / Items1;
                    dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["PorcCert"] = PorcCert;

                }
                else
                {
                    int.TryParse(filaInformeMuestra["Certificado"].ToString(), out Certfic);
                    Items1 = int.Parse(filaInformeMuestra["Items"].ToString());
                    PorcCert = (Certfic * 100) / Items1;
                    filaInformeMuestra["PorcCert"] = PorcCert;
                }


                




                int Env;

                int.TryParse(filaInformeMuestra["Enviado"].ToString(), out Env);
                double PorcEnv;







                if (InformeMuestraEncontrado == true)
                {
                    int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Enviado"].ToString(), out Env);
                    PorcEnv = (Env * 100) / Items1;
                    dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["PorcEnv"] = PorcEnv;

                }
                else
                {
                    int.TryParse(filaInformeMuestra["Enviado"].ToString(), out Env);
                    PorcEnv = (Env * 100) / Items1;
                    filaInformeMuestra["PorcEnv"] = PorcEnv;
                }





                double PorcTot = (((PorcEnv + PorcCert) * 100) / 200);

                if (InformeMuestraEncontrado == true)
                {
                    dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["PorcTotal"] = PorcTot;

                }
                else
                {
                    filaInformeMuestra["PorcTotal"] = PorcTot;
                }

                */


                if (fila[6].ToString() == "1")
                {
                    if (InformeMuestraEncontrado == true)
                    {
                        int CantAtraso;

                        int.TryParse(dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Atraso"].ToString(), out CantAtraso);
                        dtInformeMuestra.Rows[FilaEncontradaInformeMuestra]["Atraso"] = CantAtraso + 1;

                    }
                    else
                    {
                        filaInformeMuestra["Atraso"] = 1;
                    }

                }

                if (InformeMuestraEncontrado == false)
                {
                    dtInformeMuestra.Rows.Add(filaInformeMuestra);

                }

            }
        }

        private void CargarEntrega(int Entrega)
        {
            switch (Entrega)
            {
                case 1:
                    filaInformeMuestra["Categoria2"] = "Muy Bueno";
                    break;

                case 2:
                    filaInformeMuestra["Categoria2"] = "Bueno";
                    break;

                case 3:
                    filaInformeMuestra["Categoria2"] = "Regular";
                    break;

                case 4:
                    filaInformeMuestra["Categoria2"] = "Malo";
                    break;

                default:
                    filaInformeMuestra["Categoria2"] = "Sin Calificar";
                    break;

            }
        }

        //CARGO LA CALIDAD DEL PROVEEDOR SEGUN EL NUMERO
        private void CargarCalidad(int Calidad)
        {
            switch (Calidad)
            {
                case 1:
                    filaInformeMuestra["Categoria1"] = "A";

                    break;

                case 2:
                    filaInformeMuestra["Categoria1"] = "B";
                    break;

                case 3:
                    filaInformeMuestra["Categoria1"] = "C";
                    //filaEval["Categoria1"] = "C";
                    break;

                case 4:
                    filaInformeMuestra["Categoria1"] = "E";

                    break;

                default:
                    filaInformeMuestra["Categoria1"] = "E";

                    break;

            }
        }

        private void BT_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow filaDG in DGV_EvalSemProve.Rows)
            {

                if (CB_TipoEva.Text == "CALIDAD")
                {
                    string Modificado = Convert.ToString(filaDG.Cells["EvaCal"].Value);
                    if (Modificado != "")
                    {
                        Prove.Codigo = Convert.ToString(filaDG.Cells["CodigoProve"].Value);

                        DateTime Hoy = DateTime.Today;
                        Prove.FechaCat = Hoy.ToString("d");

                        if (Convert.ToString(filaDG.Cells["EvaCal"].Value) == "A") Prove.Categoria1 = 1;

                        else if (Convert.ToString(filaDG.Cells["EvaCal"].Value) == "B") Prove.Categoria1 = 2;

                        else if (Convert.ToString(filaDG.Cells["EvaCal"].Value) == "C") Prove.Categoria1 = 3;

                        else if (Convert.ToString(filaDG.Cells["EvaCal"].Value) == "D") Prove.Categoria1 = 4;



                        Prove.Categoria2 = Convert.ToInt32(filaDG.Cells["CatII"].Value);



                        ActualizarProve();


                    }

                }


                if (CB_TipoEva.Text == "ENTREGA")
                {
                    string Modificado = Convert.ToString(filaDG.Cells["EvaEnt"].Value);

                    if (Modificado != "")
                    {
                        Prove.Codigo = Convert.ToString(filaDG.Cells["CodigoProve"].Value);

                        DateTime Hoy = DateTime.Today;
                        Prove.FechaCat = Hoy.ToString("d");

                        if (Convert.ToString(filaDG.Cells["EvaEnt"].Value) == "Muy Bueno") Prove.Categoria2 = 1;

                        else if (Convert.ToString(filaDG.Cells["EvaEnt"].Value) == "Bueno") Prove.Categoria2 = 2;

                        else if (Convert.ToString(filaDG.Cells["EvaEnt"].Value) == "Regular") Prove.Categoria2 = 3;

                        else if (Convert.ToString(filaDG.Cells["EvaEnt"].Value) == "Malo") Prove.Categoria2 = 4;

                        Prove.Categoria1 = Convert.ToInt32(filaDG.Cells["CatI"].Value);

                        ActualizarProve();
                    }

                }
            }

            MessageBox.Show("La evaluación se agregó con éxito", "Agregar Evaluación",
                MessageBoxButtons.OK, MessageBoxIcon.None);
            Close();
        }

        //CON ESTE METODO SE MANTINEN TODAS LAS BASES ACTUALIZADAS, YA QUE MODIFICA EL PROVEEDOR EN CADA BASE.
        private void ActualizarProve()
        {
            string Donde = "SurfactanSA";
            PBOL.Modificar(Prove, Donde);

            Donde = "Surfactan_II";
            PBOL.Modificar(Prove, Donde);

            Donde = "Surfactan_V";
            PBOL.Modificar(Prove, Donde);
        }

        private void DGV_EvalSemProve_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Prove = DGV_EvalSemProve.SelectedRows[0].Cells[2].Value.ToString();

            Int64 ProveNum = Int64.Parse(DGV_EvalSemProve.SelectedRows[0].Cells[2].Value.ToString());

            dtInformeDetalle = dtInforme.Clone();

            dtInformeDetalle.Clear();

            DataTable dtInformeProve = ESBOL.ListaInformeProve(OrdFechaDesde, ordFechaHAsta, "SurfactanSA", 1, Prove);
            CargarInformeProve(dtInformeProve);

            dtInformeProve = ESBOL.ListaInformeProve(OrdFechaDesde, ordFechaHAsta, "Surfactan_V", 1, Prove);
            CargarInformeProve(dtInformeProve);

            dtInformeProve = ESBOL.ListaInformeProve(OrdFechaDesde, ordFechaHAsta, "Surfactan_II", 1, Prove);
            CargarInformeProve(dtInformeProve);

            DetalleItems Detalle = new DetalleItems(dtInformeDetalle);
            Detalle.Show();
        }

        private void CargarInformeProve(DataTable dtInformeProve)
        {
            foreach (DataRow fila in dtInformeProve.Rows)
            {
                dtInformeDetalle.ImportRow(fila);
            }
        }

        private void TB_Desde_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                TB_Hasta.Focus();
            }
        }
       
        
    }
}
