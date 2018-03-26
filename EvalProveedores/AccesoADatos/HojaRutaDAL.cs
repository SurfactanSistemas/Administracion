using System;
using System.Configuration;
using Negocio;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AccesoADatos
{
    public class HojaRutaDAL
    {
        public System.Data.DataTable ListaFecha(string Desde, string Hasta)
        {
            DataTable dtHojaRuta = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select C.Hoja, C.Fecha, C.OrdFecha, C.Expreso, C.Chapa, C.Chofer, C.Item1, C.Item2, C.Item3, C.Item4, C.Item5, C.Item6, C.Item7, C.Item8, C.Placa, C.Rombo, C.Observaciones, C.Desexpreso  from CheckListExpo C where C.OrdFecha >=" + Desde + " and C.OrdFecha <= " + Hasta + " and C.Expreso > 0";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtHojaRuta.Load(dataReader);

                }
                return dtHojaRuta;
            }
        }
    }
}
