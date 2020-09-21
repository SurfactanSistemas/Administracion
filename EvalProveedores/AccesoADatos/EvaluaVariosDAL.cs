﻿using System;
using System.Configuration;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccesoADatos
{
    public class EvaluaVariosDAL
    {
        public void Insertar(EvaluaVarios Eva)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO EvaluaI (Clave, Proveedor, Mes, Ano, Promedio, Promedio11, Promedio22, Promedio33, Observaciones, Periodo, Tipo, Parametro1, Parametro2, Parametro3, Parametro4, Criterio1, Criterio2, Criterio3, Criterio4, Califica11, Califica12, Califica13, Califica14, Califica21, Califica22, Califica23, Califica24, Califica31, Califica32, Califica33, Califica34, Sector1, Sector2, Sector3, DesSector1, DesSector2, DesSector3) " +
                    "VALUES (@clave, @prove, @mes,  @año, @promediotot, @promedio11, @promedio22, @promedio33, @observ, @periodo, @tipo, @parametro1, @parametro2, @parametro3, @parametro4, @criterio1, @criterio2, @criterio3, @criterio4, @califica11,  @califica12, @califica13, @califica14, @califica21, @califica22, @califica23, @califica24, @califica31, @califica32, @califica33, @califica34, @sector1, @sector2, @sector3, @dessector1, @dessector2, @dessector3) ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", Eva.Clave);
                    cmd.Parameters.AddWithValue("@prove", Eva.Proveedor);
                    cmd.Parameters.AddWithValue("@mes", Eva.Mes);
                    cmd.Parameters.AddWithValue("@año", Eva.Año);
                    cmd.Parameters.AddWithValue("@promediotot", Eva.PromedioTot);
                    cmd.Parameters.AddWithValue("@promedio11", Eva.Promedio11);
                    cmd.Parameters.AddWithValue("@promedio22", Eva.Promedio22);
                    cmd.Parameters.AddWithValue("@promedio33", Eva.Promedio33);
                    cmd.Parameters.AddWithValue("@observ", Eva.Observ);
                    cmd.Parameters.AddWithValue("@periodo", Eva.Periodo);
                    cmd.Parameters.AddWithValue("@tipo", Eva.Tipo);
                    cmd.Parameters.AddWithValue("@parametro1", Eva.Param1);
                    cmd.Parameters.AddWithValue("@parametro2", Eva.Param2);
                    cmd.Parameters.AddWithValue("@parametro3", Eva.Param3);
                    cmd.Parameters.AddWithValue("@parametro4", Eva.Param4);
                    cmd.Parameters.AddWithValue("@criterio1", Eva.Criterio1);
                    cmd.Parameters.AddWithValue("@criterio2", Eva.Criterio2);
                    cmd.Parameters.AddWithValue("@criterio3", Eva.Criterio3);
                    cmd.Parameters.AddWithValue("@criterio4", Eva.Criterio4);
                    cmd.Parameters.AddWithValue("@califica11", Eva.Calif11);
                    cmd.Parameters.AddWithValue("@califica12", Eva.Calif12);
                    cmd.Parameters.AddWithValue("@califica13", Eva.Calif13);
                    cmd.Parameters.AddWithValue("@califica14", Eva.Calif14);
                    cmd.Parameters.AddWithValue("@califica21", Eva.Calif21);
                    cmd.Parameters.AddWithValue("@califica22", Eva.Calif22);
                    cmd.Parameters.AddWithValue("@califica23", Eva.Calif23);
                    cmd.Parameters.AddWithValue("@califica24", Eva.Calif24);
                    cmd.Parameters.AddWithValue("@califica31", Eva.Calif31);
                    cmd.Parameters.AddWithValue("@califica32", Eva.Calif32);
                    cmd.Parameters.AddWithValue("@califica33", Eva.Calif33);
                    cmd.Parameters.AddWithValue("@califica34", Eva.Calif34);
                    cmd.Parameters.AddWithValue("@sector1", Eva.Sector1);
                    cmd.Parameters.AddWithValue("@sector2", Eva.Sector2);
                    cmd.Parameters.AddWithValue("@sector3", Eva.Sector3);
                    cmd.Parameters.AddWithValue("@dessector1", Eva.DesSector1);
                    cmd.Parameters.AddWithValue("@dessector2", Eva.DesSector2);
                    cmd.Parameters.AddWithValue("@dessector3", Eva.DesSector3);

                    cmd.ExecuteNonQuery();

                }
            }
        }


        public EvaluaVarios BuscarUno(string Clave)
        {

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM EvaluaI WHERE Clave = @clave";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", Clave);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        MessageBox.Show(Helper.OrDefault(dataReader["Califica11"], "0").ToString());
                        EvaluaVarios Eva = new EvaluaVarios
                        {
                            Clave = Helper.OrDefault(dataReader["Clave"], "").ToString(),
                            Proveedor = Helper.OrDefault(dataReader["Proveedor"], "").ToString(),
                            Mes = (int) Helper.OrDefault(dataReader["Mes"], ""),
                            Año = (int) Helper.OrDefault(dataReader["Ano"], "0"),
                            PromedioTot = (double) Helper.OrDefault(dataReader["Promedio"], "0,0"),
                            Promedio11 = (double) Helper.OrDefault(dataReader["Promedio11"], "0,0"),
                            Promedio22 =  (double) Helper.OrDefault(dataReader["Promedio22"], "0,0"),
                            Promedio33 =  (double) Helper.OrDefault(dataReader["Promedio33"], "0,0"),
                            Observ = Helper.OrDefault(dataReader["Observaciones"], "").ToString(),
                            Periodo = Helper.OrDefault(dataReader["Periodo"], "").ToString(),
                            Tipo = Convert.ToInt32(Helper.OrDefault(dataReader["Tipo"], "").ToString()),
                            Param1 = Helper.OrDefault(dataReader["Parametro1"], "").ToString(),
                            Param2 = Helper.OrDefault(dataReader["Parametro2"], "").ToString(),
                            Param3 = Helper.OrDefault(dataReader["Parametro3"], "").ToString(),
                            Param4 = Helper.OrDefault(dataReader["Parametro4"], "").ToString(),
                            Criterio1 = Helper.OrDefault(dataReader["Criterio1"], "").ToString(),
                            Criterio2 = Helper.OrDefault(dataReader["Criterio2"], "").ToString(),
                            Criterio3 = Helper.OrDefault(dataReader["Criterio3"], "").ToString(),
                            Criterio4 = Helper.OrDefault(dataReader["Criterio4"], "").ToString(),
                            Calif11 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica11"], "0")),
                            Calif12 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica12"], "0")),
                            Calif13 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica13"], "0")),
                            Calif14 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica14"], "0")),
                            Calif21 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica21"], "0")),
                            Calif22 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica22"], "0")),
                            Calif23 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica23"], "0")),
                            Calif24 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica24"], "0")),
                            Calif31 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica31"], "0")),
                            Calif32 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica32"], "0")),
                            Calif33 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica33"], "0")),
                            Calif34 = Convert.ToInt32(Helper.OrDefault(dataReader["Califica34"], "0")),
                            Sector1 = Convert.ToInt32(Helper.OrDefault(dataReader["Sector1"], "0")),
                            Sector2 = Convert.ToInt32(Helper.OrDefault(dataReader["Sector2"], "0")),
                            Sector3 = Convert.ToInt32(Helper.OrDefault(dataReader["Sector3"], "0")),
                            DesSector1 = Helper.OrDefault(dataReader["DesSector1"], "").ToString(),
                            DesSector2 = Helper.OrDefault(dataReader["DesSector2"], "").ToString(),
                            DesSector3 = Helper.OrDefault(dataReader["DesSector3"], "").ToString(),
                        };
                        return Eva;
                    }
                }
            }

            return null;
        }


        public void Update(EvaluaVarios Eva)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE EvaluaI SET Proveedor = @prove, Mes = @mes, Ano = @Ano, Promedio = @promediotot, Promedio11 = @promedio11, Promedio22 = @promedio22, Promedio33 = @promedio33, Observaciones = @observ, Periodo = @periodo, Tipo = @tipo, Parametro1 = @parametro1, Parametro2 = @parametro2, Parametro3 = @parametro3, Parametro4 = @parametro4, Criterio1 = @criterio1, Criterio2 = @criterio2, Criterio3 = @criterio3, Criterio4 = @criterio4, Califica11 = @califica11, Califica12 = @califica12, Califica13 = @califica13, Califica14 = @califica14, Califica21 = @califica21, Califica22 = @califica22, Califica23 = @califica23, Califica24 = @califica24, Califica31 = @califica31, Califica32 = @califica32, Califica33 = @califica33, Califica34 = @califica34, Sector1 = @sector1,  Sector2 = @sector2, Sector3 = @sector3, DesSector1 = @dessector1, DesSector2 = @dessector2, DesSector3 = @dessector3 WHERE Clave = @clave";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", Eva.Clave);
                    cmd.Parameters.AddWithValue("@prove", Eva.Proveedor);
                    cmd.Parameters.AddWithValue("@mes", Eva.Mes);
                    cmd.Parameters.AddWithValue("@Ano", Eva.Año);
                    cmd.Parameters.AddWithValue("@promediotot", Eva.PromedioTot);
                    cmd.Parameters.AddWithValue("@promedio11", Eva.Promedio11);
                    cmd.Parameters.AddWithValue("@promedio22", Eva.Promedio22);
                    cmd.Parameters.AddWithValue("@promedio33", Eva.Promedio33);
                    cmd.Parameters.AddWithValue("@observ", Eva.Observ);
                    cmd.Parameters.AddWithValue("@periodo", Eva.Periodo);
                    cmd.Parameters.AddWithValue("@tipo", Eva.Tipo);
                    cmd.Parameters.AddWithValue("@parametro1", Eva.Param1);
                    cmd.Parameters.AddWithValue("@parametro2", Eva.Param2);
                    cmd.Parameters.AddWithValue("@parametro3", Eva.Param3);
                    cmd.Parameters.AddWithValue("@parametro4", Eva.Param4);
                    cmd.Parameters.AddWithValue("@criterio1", Eva.Criterio1);
                    cmd.Parameters.AddWithValue("@criterio2", Eva.Criterio2);
                    cmd.Parameters.AddWithValue("@criterio3", Eva.Criterio3);
                    cmd.Parameters.AddWithValue("@criterio4", Eva.Criterio4);
                    cmd.Parameters.AddWithValue("@califica11", Eva.Calif11);
                    cmd.Parameters.AddWithValue("@califica12", Eva.Calif12);
                    cmd.Parameters.AddWithValue("@califica13", Eva.Calif13);
                    cmd.Parameters.AddWithValue("@califica14", Eva.Calif14);
                    cmd.Parameters.AddWithValue("@califica21", Eva.Calif21);
                    cmd.Parameters.AddWithValue("@califica22", Eva.Calif22);
                    cmd.Parameters.AddWithValue("@califica23", Eva.Calif23);
                    cmd.Parameters.AddWithValue("@califica24", Eva.Calif24);
                    cmd.Parameters.AddWithValue("@califica31", Eva.Calif31);
                    cmd.Parameters.AddWithValue("@califica32", Eva.Calif32);
                    cmd.Parameters.AddWithValue("@califica33", Eva.Calif33);
                    cmd.Parameters.AddWithValue("@califica34", Eva.Calif34);
                    cmd.Parameters.AddWithValue("@sector1", Eva.Sector1);
                    cmd.Parameters.AddWithValue("@sector2", Eva.Sector2);
                    cmd.Parameters.AddWithValue("@sector3", Eva.Sector3);
                    cmd.Parameters.AddWithValue("@dessector1", Eva.DesSector1);
                    cmd.Parameters.AddWithValue("@dessector2", Eva.DesSector2);
                    cmd.Parameters.AddWithValue("@dessector3", Eva.DesSector3);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public System.Data.DataTable Lista()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM EvaluaI where Tipo <> 1 ORDER BY Clave ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }


        public System.Data.DataTable EvaServ(Int64 Prove, string Desde, string Hasta, int Tipo1, int Tipo2)
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select E.Proveedor, E.Mes, E.Ano, E.Promedio, E.Observaciones, E.Periodo, E.Tipo, E.Parametro1, E.Parametro2, E.Parametro3, E.Parametro4, E.Parametro5, E.Criterio1, E.Criterio2, E.Criterio3, E.Criterio4, E.Califica11, E.Califica12, E.Califica13, E.Califica14, E.Califica15, E.Califica21, E.Califica22, E.Califica23, E.Califica24, E.Califica25, E.Califica31, E.Califica32, E.Califica33, E.Califica34, E.Califica35, E.DesSector1, E.DesSector2, E.DesSector3, E.Sector1, E.Sector2, E.Sector3, P.Nombre, P.Estado from EvaluaI E LEFT OUTER JOIN Proveedor P ON P.Proveedor = E.Proveedor where E.Proveedor = " + Prove + " and E.Periodo between " + Desde + " and " + Hasta + " and E.Tipo between " + Tipo1 + " and " + Tipo2;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }

    }

    class Helper
    {
        public static object OrDefault(object valor, object def)
        {
            return valor == null || valor is DBNull ? def : valor;
        }
    }
}
