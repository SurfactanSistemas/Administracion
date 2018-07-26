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

        public System.Data.DataTable ListaGen()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "select e.Clave, e.Proveedor, p.Nombre as NombProve, ISNULL(p.Estado, '') As ProveEstado, e.Ano, e.Mes, e.Promedio, e.Tipo, e.Periodo, e.Observaciones from EvaluaI e LEFT OUTER JOIN Proveedor p ON e.Proveedor = p.Proveedor order by e.Periodo desc";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }

        public System.Data.DataTable ListaGenUltimos()
        {
            DataTable ultimos = new DataTable();

            ultimos = ListarUltimos();

            ultimos.Columns.Add("Clave");
            ultimos.Columns.Add("Ano");
            ultimos.Columns.Add("Mes");
            ultimos.Columns.Add("Promedio");
            ultimos.Columns.Add("Observaciones");
            ultimos.Columns.Add("NombProve");
            ultimos.Columns.Add("ProveEstado");

            DataTable dtEval = ultimos.Clone();
            DataRow row;

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "";

                foreach (DataRow _r in ultimos.Rows)
                {
                    sqlQuery = "Select e.Clave, e.Periodo, e.Proveedor, p.Nombre As NombProve, ISNULL(p.Estado, '') As ProveEstado, e.Ano, e.Mes, e.Promedio, e.Tipo, e.Observaciones from EvaluaI e LEFT OUTER JOIN Proveedor p ON e.Proveedor = p.Proveedor Where e.Proveedor = '" + _r["Proveedor"] + "' AND e.Tipo = '" + _r["Tipo"] + "' AND e.Periodo = '" + _r["Periodo"] + "'";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.HasRows)
                        {
                            row = dtEval.NewRow();

                            row["Clave"] = dr["Clave"];
                            row["Proveedor"] = dr["Proveedor"];
                            row["NombProve"] = dr["NombProve"];
                            row["ProveEstado"] = dr["ProveEstado"];
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

        private System.Data.DataTable ListarUltimos()
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
