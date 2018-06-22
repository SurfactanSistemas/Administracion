using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class EvaGeneralDAL
    {

        public void Eliminar(string Clave)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM EvaluaI WHERE Clave = @clave";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", Clave);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public string ObtenerObservaciones(string clave)
        {
            string obs = "";
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "SELECT Observaciones FROM EvaluaI WHERE Clave = '" + clave + "'";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    if (dataReader.HasRows)
                    {
                        obs = dataReader[0].ToString().Trim();
                    }
                }

            }

            return obs;
        }

        public int Ultimo()
        {
            int Ult = 0;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "select max (Clave) as Clave from EvaluaI";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    Ult = Convert.ToInt32(dataReader[0]);

                }

            }

            return Ult;
        }

        public DataTable ListaGen()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "select Clave, Proveedor, Ano, Mes, Promedio, Tipo, Periodo, Observaciones from EvaluaI order by Periodo desc";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }

        public DataTable ListaGenUltimos()
        {
            DataTable ultimos = new DataTable();

            ultimos = ListarUltimos();

            ultimos.Columns.Add("Clave");
            ultimos.Columns.Add("Ano");
            ultimos.Columns.Add("Mes");
            ultimos.Columns.Add("Promedio");
            ultimos.Columns.Add("Observaciones");

            DataTable dtEval = ultimos.Clone();
            DataRow row;

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "";

                foreach (DataRow _r in ultimos.Rows)
                {
                    sqlQuery = "Select Clave, Periodo, Proveedor, Ano, Mes, Promedio, Tipo, Observaciones from EvaluaI Where Proveedor = '" + _r["Proveedor"] + "' AND Tipo = '" + _r["Tipo"] + "' AND Periodo = '" + _r["Periodo"] + "'";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            row = dtEval.NewRow();

                            row["Clave"] = dr["Clave"];
                            row["Proveedor"] = dr["Proveedor"];
                            row["Ano"] = dr["Ano"];
                            row["Mes"] = dr["Mes"];
                            row["Promedio"] = dr["Promedio"];
                            row["Observaciones"] = dr["Observaciones"];
                            row["Periodo"] = dr["Periodo"];
                            row["Tipo"] = dr["Tipo"];

                            dtEval.Rows.Add(row);

                            dr.Close();
                        }

                    }
                }
                
            }
            return dtEval;
        }

        private DataTable ListarUltimos()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "Select Proveedor, Tipo, MAX(Periodo) as Periodo FROM EvaluaI group by Proveedor, Tipo";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }
    }
}
