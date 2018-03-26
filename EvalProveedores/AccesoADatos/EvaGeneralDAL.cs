using System;
using System.Configuration;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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

        public System.Data.DataTable ListaGen()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "select top 100 * from EvaluaI order by Periodo desc";
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
