using System;
using System.Configuration;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AccesoADatos
{
    public class ProveedorDAL
    {
        public List<Proveedor> ListarTodos()
        {
            List<Proveedor> Proveedores = new List<Proveedor>();
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Proveedor ORDER BY CODIGO ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {

                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        Proveedor proveedor_ = new Proveedor
                        
                        {
                            Codigo = Convert.ToString(dataReader["Codigo"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Estado = Convert.ToInt32(dataReader["Estado"]),

                            

                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        Proveedores.Add(proveedor_);
                    }
                }
            }
            return Proveedores;
        }

        public System.Data.DataTable Lista()
        {
            DataTable dtProveedores = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT Proveedor, Nombre, Estado FROM Proveedor ORDER BY Proveedor ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    
                    dtProveedores.Load(dataReader);
                    
                }
            }
            return dtProveedores;
        }

        public Proveedor BuscarUno(string Codigo)
        {
            int Esta;
            int CateI;
            int CateII;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();

                 string sqlGetById = "SELECT * FROM Proveedor WHERE Proveedor = '" + Codigo +"'";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    //cmd.Parameters.AddWithValue("@codigo", Codigo);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        if (dataReader[50].ToString() == "")
                        {
                            Esta = 0;
                        }
                        else
                        {
                            if ((int.Parse(dataReader[50].ToString()) != 1) && (int.Parse(dataReader[50].ToString()) != 0) && (int.Parse(dataReader[50].ToString()) != 2))
                            {
                                Esta = 0;
                            }
                            else
                            {
                                Esta = Convert.ToInt32(dataReader["Estado"]);
                            }
                        }

                        if (dataReader["CategoriaI"].ToString() == "")
                        {
                            CateI = 0;
                        }
                        else
                        {
                            if ((int.Parse(dataReader["CategoriaI"].ToString()) != 1) && (int.Parse(dataReader["CategoriaI"].ToString()) != 2) && (int.Parse(dataReader["CategoriaI"].ToString()) != 3) && (int.Parse(dataReader["CategoriaI"].ToString()) != 4))
                            {
                                CateI = 0;
                            }
                            else
                            {
                                CateI = Convert.ToInt32(dataReader["CategoriaI"]);
                            }
                        }

                        if (dataReader["CategoriaII"].ToString() == "")
                        {
                            CateII = 0;
                        }
                        else
                        {
                            if ((int.Parse(dataReader["CategoriaII"].ToString()) != 1) && (int.Parse(dataReader["CategoriaII"].ToString()) != 2) && (int.Parse(dataReader["CategoriaII"].ToString()) != 3) && (int.Parse(dataReader["CategoriaII"].ToString()) != 4))
                            {
                                CateII = 0;
                            }
                            else
                            {
                                CateII = Convert.ToInt32(dataReader["CategoriaII"]);
                            }
                        }
                        



                        Proveedor Prove = new Proveedor
                        {
                            Codigo = Convert.ToString(dataReader["Proveedor"]),
                            Descripcion = Convert.ToString(dataReader["Nombre"]),
                            Observac = Convert.ToString(dataReader["Observaciones"]),
                            Estado = Esta,
                            Categoria1 = CateI,
                            Categoria2 = CateII,
                            FechaCat = Convert.ToString(dataReader["FechaCategoria"]),
                        };

                        return Prove;
                    }
                    else
                    {
                        Proveedor Prove = new Proveedor
                        {
                            Codigo = "",
                            Descripcion = "",
                            Estado = 0,
                        };

                        return Prove;
                    }
                }
            }

            return null;
        }

        public DataTable Lista(string RubroDesde)
        {
            DataTable dtProveedores = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                 string sqlQuery = "select P.Proveedor, P.Nombre, P.Direccion, P.Telefono, P.Estado, P.Califica, P.FechaCalifica, T.Descripcion  from Proveedor P,  TipoProv T Where P.TipoProv = T.Codigo and P.TipoProv = " +RubroDesde + " order by P.TipoProv asc";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtProveedores.Load(dataReader);

                }
            }
            return dtProveedores;
        }

        public DataTable ListaRubro(string RubroDesde)
        {
            DataTable dtProveedores = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                string sqlQuery = "select P.Proveedor, P.Nombre, P.Direccion, P.Telefono, P.Estado, P.Califica, P.FechaCalifica, T.Descripcion  from Proveedor P,  TipoProv T Where P.TipoProv = T.Codigo and P.TipoProv = " + RubroDesde + " order by P.Nombre desc";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtProveedores.Load(dataReader);

                }
            }
            return dtProveedores;
        }

        public System.Data.DataTable ListaPorTipo(int Tipo)
        {
            DataTable dtProve = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select P.Proveedor, P.Nombre, P.Observaciones  from Proveedor P where TipoProv = " + Tipo + "order by P.Nombre";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtProve.Load(dataReader);

                }
                return dtProve;
            }
        }

        public System.Data.DataTable ListaSinTipo()
        {
            DataTable dtProve = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select P.Proveedor, P.Nombre, P.Observaciones from Proveedor P where TipoProv <> 15 or TipoProv <> 8 ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtProve.Load(dataReader);

                }
                return dtProve;
            }
        }

        public void Update(Proveedor Proveedor, string Donde)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[Donde].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "update Proveedor set FechaCategoria = @FechaCat, CategoriaI = @CatI, CategoriaII = @CatII WHERE proveedor = @codigo";
                    
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", Proveedor.Codigo);
                    cmd.Parameters.AddWithValue("@FechaCat", Proveedor.FechaCat);
                    cmd.Parameters.AddWithValue("@CatI", Proveedor.Categoria1);
                    cmd.Parameters.AddWithValue("@CatII", Proveedor.Categoria2);
                    

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Inhabilitar(Proveedor Proveedor, string Donde)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[Donde].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "update Proveedor set Estado = 2 WHERE proveedor = @codigo";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@codigo", Proveedor.Codigo);
                    


                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
