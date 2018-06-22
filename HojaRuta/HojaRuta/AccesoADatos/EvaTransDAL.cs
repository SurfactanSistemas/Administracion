using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace AccesoADatos
{
    public class EvaTransDAL
    {

        public void Insertar(EvaluaTransp EvaTrans)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO EvaluaI (Clave, Proveedor, Mes, Ano, Evaluador, Camion1, Camion2, Camion3, Chofer1, Chofer2, Chofer3, Punto11, Punto12, Punto13, Punto14, Punto15, Punto21, Punto22, Punto23, Punto24, Punto25, Punto31, Punto32, Punto33, Punto34, Punto35, Promedio, Promedio1, Promedio2, Promedio3, Promedio4, Promedio5, Promedio11, Promedio22, Promedio33, Observaciones, DesChofer1, DesChofer2, DesChofer3, Dominio1, Dominio2, Dominio3, Fecha, Vencimiento, Periodo, Tipo) " +
                    "VALUES (@clave, @prove, @mes,  @año, @evaluador, @camion1, @camion2, @camion3, @chofer1, @chofer2, @chofer3, @punntaje11, @punntaje12, @punntaje13, @punntaje14, @punntaje15,  @punntaje21, @punntaje22, @punntaje23, @punntaje24, @punntaje25, @punntaje31, @punntaje32, @punntaje33, @punntaje34, @punntaje35, @promediotot, @promedio1, @promedio2, @promedio3, @promedio4, @promedio5, @promedio11, @promedio22, @promedio33, @observ, @descchofer1, @descchofer2, @descchofer3, @dominio1, @dominio2, @dominio3, @fecha, @fechavenc, @periodo, @tipo ) ";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", EvaTrans.Clave);
                    cmd.Parameters.AddWithValue("@prove", EvaTrans.Proveedor);
                    cmd.Parameters.AddWithValue("@mes", EvaTrans.Mes);
                    cmd.Parameters.AddWithValue("@año", EvaTrans.Año);
                    cmd.Parameters.AddWithValue("@evaluador", EvaTrans.Evaluador);
                    cmd.Parameters.AddWithValue("@camion1", EvaTrans.Camion1);
                    cmd.Parameters.AddWithValue("@camion2", EvaTrans.Camion2);
                    cmd.Parameters.AddWithValue("@camion3", EvaTrans.Camion3);
                    cmd.Parameters.AddWithValue("@chofer1", EvaTrans.Chofer1);
                    cmd.Parameters.AddWithValue("@chofer2", EvaTrans.Chofer2);
                    cmd.Parameters.AddWithValue("@chofer3", EvaTrans.Chofer3);
                    cmd.Parameters.AddWithValue("@punntaje11", EvaTrans.Puntaje11);
                    cmd.Parameters.AddWithValue("@punntaje12", EvaTrans.Puntaje12);
                    cmd.Parameters.AddWithValue("@punntaje13", EvaTrans.Puntaje13);
                    cmd.Parameters.AddWithValue("@punntaje14", EvaTrans.Puntaje14);
                    cmd.Parameters.AddWithValue("@punntaje15", EvaTrans.Puntaje15);
                    cmd.Parameters.AddWithValue("@punntaje21", EvaTrans.Puntaje21);
                    cmd.Parameters.AddWithValue("@punntaje22", EvaTrans.Puntaje22);
                    cmd.Parameters.AddWithValue("@punntaje23", EvaTrans.Puntaje23);
                    cmd.Parameters.AddWithValue("@punntaje24", EvaTrans.Puntaje24);
                    cmd.Parameters.AddWithValue("@punntaje25", EvaTrans.Puntaje25);
                    cmd.Parameters.AddWithValue("@punntaje31", EvaTrans.Puntaje31);
                    cmd.Parameters.AddWithValue("@punntaje32", EvaTrans.Puntaje32);
                    cmd.Parameters.AddWithValue("@punntaje33", EvaTrans.Puntaje33);
                    cmd.Parameters.AddWithValue("@punntaje34", EvaTrans.Puntaje34);
                    cmd.Parameters.AddWithValue("@punntaje35", EvaTrans.Puntaje35);
                    cmd.Parameters.AddWithValue("@promediotot", EvaTrans.PromedioTot);
                    cmd.Parameters.AddWithValue("@promedio1", EvaTrans.Promedio1);
                    cmd.Parameters.AddWithValue("@promedio2", EvaTrans.Promedio2);
                    cmd.Parameters.AddWithValue("@promedio3", EvaTrans.Promedio3);
                    cmd.Parameters.AddWithValue("@promedio4", EvaTrans.Promedio4);
                    cmd.Parameters.AddWithValue("@promedio5", EvaTrans.Promedio5);
                    cmd.Parameters.AddWithValue("@promedio11", EvaTrans.Promedio11);
                    cmd.Parameters.AddWithValue("@promedio22", EvaTrans.Promedio22);
                    cmd.Parameters.AddWithValue("@promedio33", EvaTrans.Promedio33);
                    cmd.Parameters.AddWithValue("@observ", EvaTrans.Observ);
                    cmd.Parameters.AddWithValue("@descchofer1", EvaTrans.DescChofer1);
                    cmd.Parameters.AddWithValue("@descchofer2", EvaTrans.DescChofer2);
                    cmd.Parameters.AddWithValue("@descchofer3", EvaTrans.DescChofer3);
                    cmd.Parameters.AddWithValue("@dominio1", EvaTrans.Dominio1);
                    cmd.Parameters.AddWithValue("@dominio2", EvaTrans.Dominio2);
                    cmd.Parameters.AddWithValue("@dominio3", EvaTrans.Dominio3);
                    cmd.Parameters.AddWithValue("@fecha", EvaTrans.Fecha);
                    cmd.Parameters.AddWithValue("@fechavenc", EvaTrans.FechaVenc);
                    cmd.Parameters.AddWithValue("@periodo", EvaTrans.Periodo);
                    cmd.Parameters.AddWithValue("@tipo", EvaTrans.Tipo);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public EvaluaTransp BuscarUno(string Clave)
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
                        EvaluaTransp EvaluaTra = new EvaluaTransp
                        {

                            Clave = Convert.ToString(dataReader["Clave"]),
                            Proveedor = Convert.ToString(dataReader["Proveedor"]),
                            Mes = Convert.ToInt32(dataReader["Mes"]),
                            Año = Convert.ToInt32(dataReader["Ano"]),
                            Evaluador = Convert.ToString(dataReader["Evaluador"]),
                            Camion1 = Convert.ToInt32(dataReader["Camion1"]),
                            Camion2 = Convert.ToInt32(dataReader["Camion2"]),
                            Camion3 = Convert.ToInt32(dataReader["Camion3"]),
                            Chofer1 = Convert.ToInt32(dataReader["Chofer1"]),
                            Chofer2 = Convert.ToInt32(dataReader["Chofer2"]),
                            Chofer3 = Convert.ToInt32(dataReader["Chofer3"]),
                            Puntaje11 = Convert.ToDouble(dataReader["Punto11"]),
                            Puntaje12 = Convert.ToDouble(dataReader["Punto12"]),
                            Puntaje13 = Convert.ToDouble(dataReader["Punto13"]),
                            Puntaje14 = Convert.ToDouble(dataReader["Punto14"]),
                            Puntaje15 = Convert.ToDouble(dataReader["Punto15"]),
                            Puntaje21 = Convert.ToDouble(dataReader["Punto21"]),
                            Puntaje22 = Convert.ToDouble(dataReader["Punto22"]),
                            Puntaje23 = Convert.ToDouble(dataReader["Punto23"]),
                            Puntaje24 = Convert.ToDouble(dataReader["Punto24"]),
                            Puntaje25 = Convert.ToDouble(dataReader["Punto25"]),
                            Puntaje31 = Convert.ToDouble(dataReader["Punto31"]),
                            Puntaje32 = Convert.ToDouble(dataReader["Punto32"]),
                            Puntaje33 = Convert.ToDouble(dataReader["Punto33"]),
                            Puntaje34 = Convert.ToDouble(dataReader["Punto34"]),
                            Puntaje35 = Convert.ToDouble(dataReader["Punto35"]),
                            PromedioTot  = Convert.ToDouble(dataReader["Promedio"]),
                            Promedio1  = Convert.ToDouble(dataReader["Promedio1"]),
                            Promedio2 = Convert.ToDouble(dataReader["Promedio2"]),
                            Promedio3 = Convert.ToDouble(dataReader["Promedio3"]),
                            Promedio4 = Convert.ToDouble(dataReader["Promedio4"]),
                            Promedio5 = Convert.ToDouble(dataReader["Promedio5"]),
                            Promedio11 = Convert.ToDouble(dataReader["Promedio11"]),
                            Promedio22 = Convert.ToDouble(dataReader["Promedio22"]),
                            Promedio33 = Convert.ToDouble(dataReader["Promedio33"]),
                            Observ = Convert.ToString(dataReader["Observaciones"]),
                            DescChofer1 = Convert.ToString(dataReader["DesChofer1"]),
                            DescChofer2 = Convert.ToString(dataReader["DesChofer2"]),
                            DescChofer3 = Convert.ToString(dataReader["DesChofer3"]),
                            Dominio1 = Convert.ToString(dataReader["Dominio1"]),
                            Dominio2 = Convert.ToString(dataReader["Dominio2"]),
                            Dominio3 = Convert.ToString(dataReader["Dominio3"]),
                            Fecha = Convert.ToString(dataReader["Fecha"]),
                            FechaVenc = Convert.ToString(dataReader["Vencimiento"]),
                            Periodo = Convert.ToString(dataReader["Periodo"]),
                            Tipo = Convert.ToInt32(dataReader["Tipo"])

                        };

                        return EvaluaTra;
                    }
                }
            }

            return null;
        }


        public void Update(EvaluaTransp EvaTrans)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE EvaluaI SET Proveedor = @prove, Mes = @mes, Ano = @año, Evaluador= @evaluador, Camion1 = @camion1, Camion2 = @camion2, Camion3 = @camion3, Chofer1 = @chofer1, Chofer2 = @chofer2, Chofer3 = @chofer3, Punto11 = @punntaje11, Punto12 = @punntaje12, Punto13 = @punntaje13, Punto14 = @punntaje14, Punto15 = @punntaje15, Punto21 = @punntaje21, Punto22 = @punntaje22, Punto23 = @punntaje23, Punto24 = @punntaje24, Punto25 = @punntaje25, Punto31 = @punntaje31, Punto32 = @punntaje32, Punto33 = @punntaje33, Punto34 = @punntaje34, Punto35 = @punntaje35, Promedio = @promediotot, Promedio1 = @promedio1, Promedio2 = @promedio2, Promedio3 = @promedio3, Promedio4 = @promedio4, Promedio5 = @promedio5, Promedio11 = @promedio11, Promedio22 = @promedio22, Promedio33 = @promedio33, Observaciones = @observ, DesChofer1 = @descchofer1, DesChofer2 = @descchofer2, DesChofer3 = @descchofer3, Dominio1 = @dominio1, Dominio2 = @dominio2, Dominio3 = @dominio3, Fecha = @fecha, Vencimiento = @fechavenc, Periodo = @periodo, Tipo = @tipo  WHERE Clave = @clave";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@clave", EvaTrans.Clave);
                    cmd.Parameters.AddWithValue("@prove", EvaTrans.Proveedor);
                    cmd.Parameters.AddWithValue("@mes", EvaTrans.Mes);
                    cmd.Parameters.AddWithValue("@año", EvaTrans.Año);
                    cmd.Parameters.AddWithValue("@evaluador", EvaTrans.Evaluador);
                    cmd.Parameters.AddWithValue("@camion1", EvaTrans.Camion1);
                    cmd.Parameters.AddWithValue("@camion2", EvaTrans.Camion2);
                    cmd.Parameters.AddWithValue("@camion3", EvaTrans.Camion3);
                    cmd.Parameters.AddWithValue("@chofer1", EvaTrans.Chofer1);
                    cmd.Parameters.AddWithValue("@chofer2", EvaTrans.Chofer2);
                    cmd.Parameters.AddWithValue("@chofer3", EvaTrans.Chofer3);
                    cmd.Parameters.AddWithValue("@punntaje11", EvaTrans.Puntaje11);
                    cmd.Parameters.AddWithValue("@punntaje12", EvaTrans.Puntaje12);
                    cmd.Parameters.AddWithValue("@punntaje13", EvaTrans.Puntaje13);
                    cmd.Parameters.AddWithValue("@punntaje14", EvaTrans.Puntaje14);
                    cmd.Parameters.AddWithValue("@punntaje15", EvaTrans.Puntaje15);
                    cmd.Parameters.AddWithValue("@punntaje21", EvaTrans.Puntaje21);
                    cmd.Parameters.AddWithValue("@punntaje22", EvaTrans.Puntaje22);
                    cmd.Parameters.AddWithValue("@punntaje23", EvaTrans.Puntaje23);
                    cmd.Parameters.AddWithValue("@punntaje24", EvaTrans.Puntaje24);
                    cmd.Parameters.AddWithValue("@punntaje25", EvaTrans.Puntaje25);
                    cmd.Parameters.AddWithValue("@punntaje31", EvaTrans.Puntaje31);
                    cmd.Parameters.AddWithValue("@punntaje32", EvaTrans.Puntaje32);
                    cmd.Parameters.AddWithValue("@punntaje33", EvaTrans.Puntaje33);
                    cmd.Parameters.AddWithValue("@punntaje34", EvaTrans.Puntaje34);
                    cmd.Parameters.AddWithValue("@punntaje35", EvaTrans.Puntaje35);
                    cmd.Parameters.AddWithValue("@promediotot", EvaTrans.PromedioTot);
                    cmd.Parameters.AddWithValue("@promedio1", EvaTrans.Promedio1);
                    cmd.Parameters.AddWithValue("@promedio2", EvaTrans.Promedio2);
                    cmd.Parameters.AddWithValue("@promedio3", EvaTrans.Promedio3);
                    cmd.Parameters.AddWithValue("@promedio4", EvaTrans.Promedio4);
                    cmd.Parameters.AddWithValue("@promedio5", EvaTrans.Promedio5);
                    cmd.Parameters.AddWithValue("@promedio11", EvaTrans.Promedio11);
                    cmd.Parameters.AddWithValue("@promedio22", EvaTrans.Promedio22);
                    cmd.Parameters.AddWithValue("@promedio33", EvaTrans.Promedio33);
                    cmd.Parameters.AddWithValue("@observ", EvaTrans.Observ);
                    cmd.Parameters.AddWithValue("@descchofer1", EvaTrans.DescChofer1);
                    cmd.Parameters.AddWithValue("@descchofer2", EvaTrans.DescChofer2);
                    cmd.Parameters.AddWithValue("@descchofer3", EvaTrans.DescChofer3);
                    cmd.Parameters.AddWithValue("@dominio1", EvaTrans.Dominio1);
                    cmd.Parameters.AddWithValue("@dominio2", EvaTrans.Dominio2);
                    cmd.Parameters.AddWithValue("@dominio3", EvaTrans.Dominio3);
                    cmd.Parameters.AddWithValue("@fecha", EvaTrans.Fecha);
                    cmd.Parameters.AddWithValue("@fechavenc", EvaTrans.FechaVenc);
                    cmd.Parameters.AddWithValue("@periodo", EvaTrans.Periodo);
                    cmd.Parameters.AddWithValue("@tipo", EvaTrans.Tipo);

                    cmd.ExecuteNonQuery();

                }
            }


        }



        

        


        public DataTable Lista()
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                const string sqlQuery = "SELECT TOP 100 * FROM EvaluaI where Tipo = 1 ORDER BY Clave ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtEval.Load(dataReader);

                }
                return dtEval;
            }
        }

        public DataTable ListaProveFecha(string Desde, string Hasta, string Proveedor)
        {
            DataTable dtEval = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select * from EvaluaI where Periodo between " + Desde + " and " + Hasta +   " and Proveedor = " + Proveedor + " order by Clave";
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
