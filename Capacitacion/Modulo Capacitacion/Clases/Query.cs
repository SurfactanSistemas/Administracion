using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
namespace Modulo_Capacitacion.Clases
{
    static class Query
    {
        public static DataRow GetSingle(string q)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                cn.Open();

                using (SqlCommand cm = new SqlCommand(q))
                {
                    cm.Connection = cn;

                    using (SqlDataReader dr = cm.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        tabla.Load(dr);
                    }
                }
            }

            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];

            return null/* TODO Change to default(_) if this is not a reference type */;
        }

        public static DataTable GetAll(string q)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                cn.Open();

                using (SqlCommand cm = new SqlCommand(q))
                {
                    cm.Connection = cn;

                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        tabla.Load(dr);
                    }
                }
            }

            return tabla;
        }

        public static SqlDataReader ExecuteQueryRead(string q)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;

            cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
            cn.Open();

            cm.Connection = cn;
            cm.CommandText = q;

            dr = cm.ExecuteReader();

            return dr;
        }

        public static void ExecuteNonQueries(params string[] q)
        {
            SqlTransaction trans = null;
            try
            {
                if (q.Length == 0)
                    throw new Exception("No se han pasado consultas para ejecutar.");

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                    cn.Open();
                    trans = cn.BeginTransaction();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;
                        cm.Transaction = trans;

                        foreach (string _q in q)
                        {
                            cm.CommandText = _q;
                            cm.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!Information.IsNothing(trans) && !Information.IsNothing(trans.Connection))
                    trans.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteNonQueries(params string[] q)
        {
            SqlTransaction trans = null;
            try
            {
                if (q.Length == 0)
                    throw new Exception("No se han pasado consultas para ejecutar.");

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                    cn.Open();
                    trans = cn.BeginTransaction();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;
                        cm.Transaction = trans;

                        foreach (string _q in q)
                        {
                            cm.CommandText = _q;
                            cm.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!Information.IsNothing(trans) && !Information.IsNothing(trans.Connection))
                    trans.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public static DataTable CallProcedureWithReturns(string proc, Dictionary<string, object> @params)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ToString();
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = proc;
                        cm.Connection = cn;

                        foreach (KeyValuePair<string, object> v in @params)
                        {
                            SqlParameter p = new SqlParameter();
                            p.SqlDbType = SqlDbType.VarChar;
                            p.Value = v.Value;
                            p.ParameterName = v.Key;
                            cm.Parameters.Add(p);
                        }

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            tabla.Load(dr);
                        }
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
