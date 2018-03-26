using System;
using System.Configuration;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AccesoADatos
{
    public class InformeConsolDAL
    {

        public System.Data.DataTable Lista()
        {
            DataTable dtInforme = new DataTable();
            
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {

                cnx.Open();
                string sqlQuery = "select * from InformeConsol order by Informe asc";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtInforme.Load(dataReader);

                }
                return dtInforme;
            }
        }
    }
}
