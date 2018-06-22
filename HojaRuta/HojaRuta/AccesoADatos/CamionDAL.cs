using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace AccesoADatos
{
    public class CamionDAL
    {

        public void Insertar(Camion Camion)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Camion (Codigo, Descripcion, Patente, CodigoEmpresa, AplicaV, FechaVtoI, FechaVtoII, FechaVtoIII, FechaVtoIV, FechaVtoV, OrdFechaVtoI, OrdFechaVtoII, OrdFechaVtoIII, OrdFechaVtoIV, OrdFechaVtoV, FechaEntregaI, FechaEntregaII, FechaEntregaIII, FechaEntregaIV, FechaEntregaV, OrdFechaEntregaI, OrdFechaEntregaII, OrdFechaEntregaIII, OrdFechaEntregaIV, OrdFechaEntregaV, ComentarioI, ComentarioII, ComentarioIII, ComentarioIV, ComentarioV, Proveedor, Estado, Chofer, Titulo) " +
                    "VALUES ((select MAX(Codigo) + 1 from Camion c),@descr, @patente,  @codigoemp, @aplica, @fechavtoI, @fechavtoII, @fechavtoIII, @fechavtoIV, @fechavtoV, @ordFechaVtoI, @ordFechaVtoII, @ordFechaVtoIII, @ordFechaVtoIV, @ordFechaVtoV, @fechaEntI, @fechaEntII, @fechaEntIII, @fechaEntIV, @fechaEntV, @ordFechEntI, @ordFechEntII, @ordFechEntIII, @ordFechEntIV, @ordFechEntV, @comentI, @comentII, @comentIII, @comentIV, @comentV, @proveedor, @estado, @chofer, @titulo  ) ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@descr", Camion.Descripcion);
                    cmd.Parameters.AddWithValue("@patente", Camion.Patente);
                    cmd.Parameters.AddWithValue("@codigoemp", Camion.CodigoEmpresa);
                    cmd.Parameters.AddWithValue("@aplica", Camion.Aplica);
                    cmd.Parameters.AddWithValue("@fechavtoI", Camion.FechaVto1);
                    cmd.Parameters.AddWithValue("@fechavtoII", Camion.FechaVto2);
                    cmd.Parameters.AddWithValue("@fechavtoIII", Camion.FechaVto3);
                    cmd.Parameters.AddWithValue("@fechavtoIV", Camion.FechaVto4);
                    cmd.Parameters.AddWithValue("@fechavtoV", Camion.FechaVto5);
                    cmd.Parameters.AddWithValue("@ordFechaVtoI", Camion.OrdFechaVto1);
                    cmd.Parameters.AddWithValue("@ordFechaVtoII", Camion.OrdFechaVto2);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIII", Camion.OrdFechaVto3);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIV", Camion.OrdFechaVto4);
                    cmd.Parameters.AddWithValue("@ordFechaVtoV", Camion.OrdFechaVto5);
                    cmd.Parameters.AddWithValue("@fechaEntI", Camion.FechaEnt1);
                    cmd.Parameters.AddWithValue("@fechaEntII", Camion.FechaEnt2);
                    cmd.Parameters.AddWithValue("@fechaEntIII", Camion.FechaEnt3);
                    cmd.Parameters.AddWithValue("@fechaEntIV", Camion.FechaEnt4);
                    cmd.Parameters.AddWithValue("@fechaEntV", Camion.FechaEnt5);
                    cmd.Parameters.AddWithValue("@ordFechEntI", Camion.OrdFechaEnt1);
                    cmd.Parameters.AddWithValue("@ordFechEntII", Camion.OrdFechaEnt2);
                    cmd.Parameters.AddWithValue("@ordFechEntIII", Camion.OrdFechaEnt3);
                    cmd.Parameters.AddWithValue("@ordFechEntIV", Camion.OrdFechaEnt4);
                    cmd.Parameters.AddWithValue("@ordFechEntV", Camion.OrdFechaEnt5);
                    cmd.Parameters.AddWithValue("@comentI", Camion.Comentario1);
                    cmd.Parameters.AddWithValue("@comentII", Camion.Comentario2);
                    cmd.Parameters.AddWithValue("@comentIII", Camion.Comentario3);
                    cmd.Parameters.AddWithValue("@comentIV", Camion.Comentario4);
                    cmd.Parameters.AddWithValue("@comentV", Camion.Comentario5);
                    cmd.Parameters.AddWithValue("@proveedor", Camion.Proveedor);
                    cmd.Parameters.AddWithValue("@titulo", Camion.Titulo);
                    cmd.Parameters.AddWithValue("@chofer", Camion.Chofer);
                    cmd.Parameters.AddWithValue("@estado", Camion.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Camion> ListarTodos()
        {
            List<Camion> Camiones = new List<Camion>();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT TOP 100 * FROM Camion ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        Camion camion_ =new Camion
                        
                        {
                            Codigo = Convert.ToInt32(dataReader["Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Patente = Convert.ToString(dataReader["Patente"]),
                            CodigoEmpresa = Convert.ToInt32(dataReader["CodigoEmpresa"]),
                            Aplica = Convert.ToInt32(dataReader["AplicaV"]),
                            FechaVto1 = Convert.ToString(dataReader["FechaVtoI"]),
                            FechaVto2 = Convert.ToString(dataReader["FechaVtoII"]),
                            FechaVto3 = Convert.ToString(dataReader["FechaVtoIII"]),
                            FechaVto4 = Convert.ToString(dataReader["FechaVtoIV"]),
                            FechaVto5 = Convert.ToString(dataReader["FechaVtoV"]),
                            OrdFechaVto1 = Convert.ToString(dataReader["OrdFechaVtoI"]),
                            OrdFechaVto2 = Convert.ToString(dataReader["OrdFechaVtoII"]),
                            OrdFechaVto3 = Convert.ToString(dataReader["OrdFechaVtoIII"]),
                            OrdFechaVto4 = Convert.ToString(dataReader["OrdFechaVtoIV"]),
                            OrdFechaVto5 = Convert.ToString(dataReader["OrdFechaVtoV"]),
                            FechaEnt1 = Convert.ToString(dataReader["FechaEntregaI"]),
                            FechaEnt2 = Convert.ToString(dataReader["FechaEntregaII"]),
                            FechaEnt3 = Convert.ToString(dataReader["FechaEntregaIII"]),
                            FechaEnt4 = Convert.ToString(dataReader["FechaEntregaIV"]),
                            FechaEnt5 = Convert.ToString(dataReader["FechaEntregaV"]),
                            OrdFechaEnt1 = Convert.ToString(dataReader["OrdFechaEntregaI"]),
                            OrdFechaEnt2 = Convert.ToString(dataReader["OrdFechaEntregaII"]),
                            OrdFechaEnt3 = Convert.ToString(dataReader["OrdFechaEntregaIII"]),
                            OrdFechaEnt4 = Convert.ToString(dataReader["OrdFechaEntregaIV"]),
                            OrdFechaEnt5 = Convert.ToString(dataReader["OrdFechaEntregaV"]),
                            Comentario1 = Convert.ToString(dataReader["ComentarioI"]),
                            Comentario2 = Convert.ToString(dataReader["ComentarioII"]),
                            Comentario3 = Convert.ToString(dataReader["ComentarioIII"]),
                            Comentario4 = Convert.ToString(dataReader["ComentarioIV"]),
                            Comentario5 = Convert.ToString(dataReader["ComentarioV"]),
                            Proveedor = Convert.ToString(dataReader["Proveedor"]),
                            Titulo = Convert.ToString(dataReader["Titulo"]),
                            Estado = Convert.ToInt32(dataReader["Estado"]),
                            Chofer = Convert.ToInt32(dataReader["Chofer"])

                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        Camiones.Add(camion_);
                    }
                }
            }
            return Camiones;
        }


        public Camion BuscarUno(int Codigo)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM Camion WHERE CODIGO = @codigo";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", Codigo);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Camion camion = new Camion
                        {
                            Codigo = Convert.ToInt32(dataReader["Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            CodigoEmpresa = Convert.ToInt32(dataReader["CodigoEmpresa"]),
                            Patente = Convert.ToString(dataReader["Patente"]),
                            Aplica = Convert.ToInt32(dataReader["AplicaV"]),
                            FechaVto1 = Convert.ToString(dataReader["FechaVtoI"]),
                            FechaVto2 = Convert.ToString(dataReader["FechaVtoII"]),
                            FechaVto3 = Convert.ToString(dataReader["FechaVtoIII"]),
                            FechaVto4 = Convert.ToString(dataReader["FechaVtoIV"]),
                            FechaVto5 = Convert.ToString(dataReader["FechaVtoV"]),
                            OrdFechaVto1 = Convert.ToString(dataReader["OrdFechaVtoI"]),
                            OrdFechaVto2 = Convert.ToString(dataReader["OrdFechaVtoII"]),
                            OrdFechaVto3 = Convert.ToString(dataReader["OrdFechaVtoIII"]),
                            OrdFechaVto4 = Convert.ToString(dataReader["OrdFechaVtoIV"]),
                            OrdFechaVto5 = Convert.ToString(dataReader["OrdFechaVtoV"]),
                            FechaEnt1 = Convert.ToString(dataReader["FechaEntregaI"]),
                            FechaEnt2 = Convert.ToString(dataReader["FechaEntregaII"]),
                            FechaEnt3 = Convert.ToString(dataReader["FechaEntregaIII"]),
                            FechaEnt4 = Convert.ToString(dataReader["FechaEntregaIV"]),
                            FechaEnt5 = Convert.ToString(dataReader["FechaEntregaV"]),
                            OrdFechaEnt1 = Convert.ToString(dataReader["OrdFechaEntregaI"]),
                            OrdFechaEnt2 = Convert.ToString(dataReader["OrdFechaEntregaII"]),
                            OrdFechaEnt3 = Convert.ToString(dataReader["OrdFechaEntregaIII"]),
                            OrdFechaEnt4 = Convert.ToString(dataReader["OrdFechaEntregaIV"]),
                            OrdFechaEnt5 = Convert.ToString(dataReader["OrdFechaEntregaV"]),
                            Comentario1 = Convert.ToString(dataReader["ComentarioI"]),
                            Comentario2 = Convert.ToString(dataReader["ComentarioII"]),
                            Comentario3 = Convert.ToString(dataReader["ComentarioIII"]),
                            Comentario4 = Convert.ToString(dataReader["ComentarioIV"]),
                            Comentario5 = Convert.ToString(dataReader["ComentarioV"]),
                            Proveedor = Convert.ToString(dataReader["Proveedor"]),
                            Titulo = Convert.ToString(dataReader["Titulo"]),
                            Estado = Convert.ToInt32(dataReader["Estado"]),
                            Chofer = Convert.ToInt32(dataReader["Chofer"])

                        };

                        return camion;
                    }
                }
            }
            return null;
        }


        public void Update(Camion Camion)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE Camion SET Descripcion = @descr, Patente = @patente, CodigoEmpresa = @codigoemp, AplicaV= @aplica, FechaVtoI = @fechavtoI, FechaVtoII = @fechavtoII, FechaVtoIII = @fechavtoIII, FechaVtoIV = @fechavtoIV, FechaVtoV = @fechavtoV, OrdFechaVtoI = @ordFechaVtoI, OrdFechaVtoII = @ordFechaVtoII, OrdFechaVtoIII = @ordFechaVtoIII, OrdFechaVtoIV = @ordFechaVtoIV, OrdFechaVtoV = @ordFechaVtoV, FechaEntregaI = @fechaEntI, FechaEntregaII = @fechaEntII, FechaEntregaIII = @fechaEntIII, FechaEntregaIV = @fechaEntIV, FechaEntregaV = @fechaEntV, OrdFechaEntregaI = @ordFechEntI, OrdFechaEntregaII = @ordFechEntII, OrdFechaEntregaIII = @ordFechEntIII, OrdFechaEntregaIV = @ordFechEntIV, OrdFechaEntregaV = @ordFechEntV, ComentarioI = @comentI, ComentarioII = @comentII, ComentarioIII = @comentIII, ComentarioIV = @comentIV, ComentarioV = @comentV, Proveedor = @proveedor, Titulo = @titulo, Chofer = @chofer, Estado = @estado  WHERE Codigo = @codigo";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", Camion.Codigo);
                    cmd.Parameters.AddWithValue("@descr", Camion.Descripcion);
                    cmd.Parameters.AddWithValue("@patente", Camion.Patente);
                    cmd.Parameters.AddWithValue("@codigoemp", Camion.CodigoEmpresa);
                    cmd.Parameters.AddWithValue("@aplica", Camion.Aplica);
                    cmd.Parameters.AddWithValue("@fechavtoI", Camion.FechaVto1);
                    cmd.Parameters.AddWithValue("@fechavtoII", Camion.FechaVto2);
                    cmd.Parameters.AddWithValue("@fechavtoIII", Camion.FechaVto3);
                    cmd.Parameters.AddWithValue("@fechavtoIV", Camion.FechaVto4);
                    cmd.Parameters.AddWithValue("@fechavtoV", Camion.FechaVto5);
                    cmd.Parameters.AddWithValue("@ordFechaVtoI", Camion.OrdFechaVto1);
                    cmd.Parameters.AddWithValue("@ordFechaVtoII", Camion.OrdFechaVto2);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIII", Camion.OrdFechaVto3);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIV", Camion.OrdFechaVto4);
                    cmd.Parameters.AddWithValue("@ordFechaVtoV", Camion.OrdFechaVto5);
                    cmd.Parameters.AddWithValue("@fechaEntI", Camion.FechaEnt1);
                    cmd.Parameters.AddWithValue("@fechaEntII", Camion.FechaEnt2);
                    cmd.Parameters.AddWithValue("@fechaEntIII", Camion.FechaEnt3);
                    cmd.Parameters.AddWithValue("@fechaEntIV", Camion.FechaEnt4);
                    cmd.Parameters.AddWithValue("@fechaEntV", Camion.FechaEnt5);
                    cmd.Parameters.AddWithValue("@ordFechEntI", Camion.OrdFechaEnt1);
                    cmd.Parameters.AddWithValue("@ordFechEntII", Camion.OrdFechaEnt2);
                    cmd.Parameters.AddWithValue("@ordFechEntIII", Camion.OrdFechaEnt3);
                    cmd.Parameters.AddWithValue("@ordFechEntIV", Camion.OrdFechaEnt4);
                    cmd.Parameters.AddWithValue("@ordFechEntV", Camion.OrdFechaEnt5);
                    cmd.Parameters.AddWithValue("@comentI", Camion.Comentario1);
                    cmd.Parameters.AddWithValue("@comentII", Camion.Comentario2);
                    cmd.Parameters.AddWithValue("@comentIII", Camion.Comentario3);
                    cmd.Parameters.AddWithValue("@comentIV", Camion.Comentario4);
                    cmd.Parameters.AddWithValue("@comentV", Camion.Comentario5);
                    cmd.Parameters.AddWithValue("@proveedor", Camion.Proveedor);
                    cmd.Parameters.AddWithValue("@titulo", Camion.Titulo);
                    cmd.Parameters.AddWithValue("@chofer", Camion.Chofer);
                    cmd.Parameters.AddWithValue("@estado", Camion.Estado);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int Codigo)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Camion WHERE Codigo = @codigo";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", Codigo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int Ultimo()
        {
            int Ult = 0;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "select max (Codigo) as Codigo from Camion";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    Ult = Convert.ToInt32(dataReader[0]);

                }

            }

            return Ult;
        }

        public DataTable Lista()
        {
            DataTable dtCamiones = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM Camion ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtCamiones.Load(dataReader);

                }
                return dtCamiones;
            }
        }

        public DataTable ListaProve(string Prove)
        {

            DataTable dtCamiones = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM Camion where Proveedor = @prove ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@prove", Prove);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtCamiones.Load(dataReader);

                }
                return dtCamiones;
            }





          }

        public DataTable ListaFecha(string Desde, string Hasta)
        {
            DataTable dtCamiones = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select C.Codigo, C.Descripcion, C.Patente, C.FechaVtoI, C.FechaVtoII, C.FechaVtoIII, C.FechaVtoIV, C.FechaVtoV, C.OrdFechaVtoI, C.OrdFechaVtoII, C.OrdFechaVtoIII, C.OrdFechaVtoIV, C.OrdFechaVtoV, C.Proveedor from Camion C where OrdFechaVtoI between " + Desde + " and " + Hasta + " or OrdFechaVtoII between " + Desde + " and " + Hasta + " or OrdFechaVtoIII between " + Desde + " and " + Hasta + " or OrdFechaVtoIV between " + Desde + " and " + Hasta + " or OrdFechaVtoV between " + Desde + " and " + Hasta + "order by Codigo desc";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtCamiones.Load(dataReader);

                }
                return dtCamiones;
            }
        }

    }
}
