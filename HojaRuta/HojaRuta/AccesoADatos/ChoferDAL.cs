using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace AccesoADatos
{
    public class ChoferDAL
    {
        public void Insertar(Chofer chofer)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Chofer (Codigo, Descripcion, CodigoEmpresa, AplicaIII, FechaVtoI, FechaVtoII, FechaVtoIII, OrdFechaVtoI, OrdFechaVtoII, OrdFechaVtoIII, FechaEntregaI, FechaEntregaII, FechaEntregaIII, OrdFechaEntregaI, OrdFechaEntregaII, OrdFechaEntregaIII, ComentarioI, ComentarioII, ComentarioIII, Proveedor, Titulo) " +
                    "VALUES ((select MAX(Codigo) + 1 from Chofer c),@descr, @codigoemp, @aplica, @fechavtoI, @fechavtoII, @fechavtoIII, @ordFechaVtoI, @ordFechaVtoII, @ordFechaVtoIII, @fechaEntI, @fechaEntII, @fechaEntIII, @ordFechEntI, @ordFechEntII, @ordFechEntIII, @comentI, @comentII, @comentIII, @proveedor, @titulo  ) ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@descr", chofer.Descripcion);
                    cmd.Parameters.AddWithValue("@codigoemp", chofer.CodigoEmpresa);
                    cmd.Parameters.AddWithValue("@aplica", chofer.Aplica);
                    cmd.Parameters.AddWithValue("@fechavtoI", chofer.FechaVto1);
                    cmd.Parameters.AddWithValue("@fechavtoII", chofer.FechaVto2);
                    cmd.Parameters.AddWithValue("@fechavtoIII", chofer.FechaVto3);
                    cmd.Parameters.AddWithValue("@ordFechaVtoI", chofer.OrdFechaVto1);
                    cmd.Parameters.AddWithValue("@ordFechaVtoII", chofer.OrdFechaVto2);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIII", chofer.OrdFechaVto3);
                    cmd.Parameters.AddWithValue("@fechaEntI", chofer.FechaEnt1);
                    cmd.Parameters.AddWithValue("@fechaEntII", chofer.FechaEnt2);
                    cmd.Parameters.AddWithValue("@fechaEntIII", chofer.FechaEnt3);
                    cmd.Parameters.AddWithValue("@ordFechEntI", chofer.OrdFechaEnt1);
                    cmd.Parameters.AddWithValue("@ordFechEntII", chofer.OrdFechaEnt2);
                    cmd.Parameters.AddWithValue("@ordFechEntIII", chofer.OrdFechaEnt3);
                    cmd.Parameters.AddWithValue("@comentI", chofer.Comentario1);
                    cmd.Parameters.AddWithValue("@comentII", chofer.Comentario2);
                    cmd.Parameters.AddWithValue("@comentIII", chofer.Comentario3);
                    cmd.Parameters.AddWithValue("@proveedor", chofer.Proveedor);
                    cmd.Parameters.AddWithValue("@titulo", chofer.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Chofer> ListarTodos()
        {
            List<Chofer> Choferes = new List<Chofer>();
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
                {
                    cnx.Open();

                    const string sqlQuery = "SELECT TOP 100 * FROM chofer ORDER BY CODIGO ASC";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        //
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            
                            //
                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            Chofer chofer_ = new Chofer
                            {
                                Codigo = Convert.ToInt32(dataReader["Codigo"]),
                                Descripcion = Convert.ToString(dataReader["Descripcion"]),
                                CodigoEmpresa = Convert.ToInt32(dataReader["CodigoEmpresa"]),
                                Aplica = Convert.ToInt32(dataReader["AplicaIII"]),
                                FechaVto1 = Convert.ToString(dataReader["FechaVtoI"]),
                                FechaVto2 = Convert.ToString(dataReader["FechaVtoII"]),
                                FechaVto3 = Convert.ToString(dataReader["FechaVtoIII"]),
                                OrdFechaVto1 = Convert.ToString(dataReader["OrdFechaVtoI"]),
                                OrdFechaVto2 = Convert.ToString(dataReader["OrdFechaVtoII"]),
                                OrdFechaVto3 = Convert.ToString(dataReader["OrdFechaVtoIII"]),
                                FechaEnt1 = Convert.ToString(dataReader["FechaEntregaI"]),
                                FechaEnt2 = Convert.ToString(dataReader["FechaEntregaII"]),
                                FechaEnt3 = Convert.ToString(dataReader["FechaEntregaIII"]),
                                OrdFechaEnt1 = Convert.ToString(dataReader["OrdFechaEntregaI"]),
                                OrdFechaEnt2 = Convert.ToString(dataReader["OrdFechaEntregaII"]),
                                OrdFechaEnt3 = Convert.ToString(dataReader["OrdFechaEntregaIII"]),
                                Comentario1 = Convert.ToString(dataReader["ComentarioI"]),
                                Comentario2 = Convert.ToString(dataReader["ComentarioII"]),
                                Comentario3 = Convert.ToString(dataReader["ComentarioIII"]),
                                Proveedor = Convert.ToString(dataReader["Proveedor"]),
                                Titulo = Convert.ToString(dataReader["Titulo"])
                                
                            };
                            //
                            //Insertamos el objeto Producto dentro de la lista Productos
                            Choferes.Add(chofer_);
                        }
                    }
                }
            return Choferes;
        }

        public Chofer BuscarUno(int Codigo)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM Chofer WHERE CODIGO = @codigo";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@codigo", Codigo);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Chofer chofer = new Chofer
                        {
                            Codigo = Convert.ToInt32(dataReader["Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            CodigoEmpresa = Convert.ToInt32(dataReader["CodigoEmpresa"]),
                            Aplica = Convert.ToInt32(dataReader["AplicaIII"]),
                            FechaVto1 = Convert.ToString(dataReader["FechaVtoI"]),
                            FechaVto2 = Convert.ToString(dataReader["FechaVtoII"]),
                            FechaVto3 = Convert.ToString(dataReader["FechaVtoIII"]),
                            OrdFechaVto1 = Convert.ToString(dataReader["OrdFechaVtoI"]),
                            OrdFechaVto2 = Convert.ToString(dataReader["OrdFechaVtoII"]),
                            OrdFechaVto3 = Convert.ToString(dataReader["OrdFechaVtoIII"]),
                            FechaEnt1 = Convert.ToString(dataReader["FechaEntregaI"]),
                            FechaEnt2 = Convert.ToString(dataReader["FechaEntregaII"]),
                            FechaEnt3 = Convert.ToString(dataReader["FechaEntregaIII"]),
                            OrdFechaEnt1 = Convert.ToString(dataReader["OrdFechaEntregaI"]),
                            OrdFechaEnt2 = Convert.ToString(dataReader["OrdFechaEntregaII"]),
                            OrdFechaEnt3 = Convert.ToString(dataReader["OrdFechaEntregaIII"]),
                            Comentario1 = Convert.ToString(dataReader["ComentarioI"]),
                            Comentario2 = Convert.ToString(dataReader["ComentarioII"]),
                            Comentario3 = Convert.ToString(dataReader["ComentarioIII"]),
                            Proveedor = Convert.ToString(dataReader["Proveedor"]),
                            Titulo = Convert.ToString(dataReader["Titulo"])

                        };

                        return chofer;
                    }
                }
            }

            return null;
        }

        public void Update(Chofer chofer)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE Chofer SET Descripcion = @descr, CodigoEmpresa = @codigoemp, AplicaIII = @aplica,  FechaVtoI = @fechavtoI, FechaVtoII = @fechavtoII, FechaVtoIII = @fechavtoIII, OrdFechaVtoI = @ordFechaVtoI, OrdFechaVtoII = @ordFechaVtoII, OrdFechaVtoIII = @ordFechaVtoIII, FechaEntregaI = @fechaEntI, FechaEntregaII = @fechaEntII, FechaEntregaIII = @fechaEntIII, OrdFechaEntregaI = @ordFechEntI, OrdFechaEntregaII = @ordFechEntII, OrdFechaEntregaIII = @ordFechEntIII, ComentarioI = @comentI, ComentarioII = @comentII, ComentarioIII = @comentIII, Proveedor = @proveedor, Titulo = @titulo  WHERE Codigo = @codigo";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", chofer.Codigo);
                    cmd.Parameters.AddWithValue("@descr", chofer.Descripcion);
                    cmd.Parameters.AddWithValue("@codigoemp", chofer.CodigoEmpresa);
                    cmd.Parameters.AddWithValue("@aplica", chofer.Aplica);
                    cmd.Parameters.AddWithValue("@fechavtoI", chofer.FechaVto1);
                    cmd.Parameters.AddWithValue("@fechavtoII", chofer.FechaVto2);
                    cmd.Parameters.AddWithValue("@fechavtoIII", chofer.FechaVto3);
                    cmd.Parameters.AddWithValue("@ordFechaVtoI", chofer.OrdFechaVto1);
                    cmd.Parameters.AddWithValue("@ordFechaVtoII", chofer.OrdFechaVto2);
                    cmd.Parameters.AddWithValue("@ordFechaVtoIII", chofer.OrdFechaVto3);
                    cmd.Parameters.AddWithValue("@fechaEntI", chofer.FechaEnt1);
                    cmd.Parameters.AddWithValue("@fechaEntII", chofer.FechaEnt2);
                    cmd.Parameters.AddWithValue("@fechaEntIII", chofer.FechaEnt3);
                    cmd.Parameters.AddWithValue("@ordFechEntI", chofer.OrdFechaEnt1);
                    cmd.Parameters.AddWithValue("@ordFechEntII", chofer.OrdFechaEnt2);
                    cmd.Parameters.AddWithValue("@ordFechEntIII", chofer.OrdFechaEnt3);
                    cmd.Parameters.AddWithValue("@comentI", chofer.Comentario1);
                    cmd.Parameters.AddWithValue("@comentII", chofer.Comentario2);
                    cmd.Parameters.AddWithValue("@comentIII", chofer.Comentario3);
                    cmd.Parameters.AddWithValue("@proveedor", chofer.Proveedor);
                    cmd.Parameters.AddWithValue("@titulo", chofer.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idproducto">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Eliminar(int Codigo)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Chofer WHERE Codigo = @codigo";
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
                const string sqlQuery = "select max (Codigo) as Codigo from Chofer";
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
            DataTable dtChoferes = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM chofer ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtChoferes.Load(dataReader);

                }
                return dtChoferes;
            }

        }
        

        public DataTable ListaProve(string Prove)
        {
            DataTable dtChoferes = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM chofer where Proveedor = @prove ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@prove", Prove);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtChoferes.Load(dataReader);

                }
                return dtChoferes;
            }

        }

        public DataTable ListaFecha(string Desde, string Hasta)
        {
            DataTable dtChoferes = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select C.Codigo, C.Descripcion, C.FechaVtoI, C.FechaVtoII, C.FechaVtoIII, C.OrdFechaVtoI, C.OrdFechaVtoII, C.OrdFechaVtoIII, C.Proveedor from Chofer C where OrdFechaVtoI between " + Desde + " and " + Hasta + " or OrdFechaVtoII between " + Desde + " and " + Hasta + " or OrdFechaVtoIII between " + Desde + " and " + Hasta + "order by Codigo desc" ;

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtChoferes.Load(dataReader);

                }
                return dtChoferes;
            }
        }
    }
}
