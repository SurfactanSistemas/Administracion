using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class EvalSemestralDAL
    {

        public DataTable ListaInforme(int Desde, int Hasta, string Donde, int Tipo)
        {
            DataTable dtInforme = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[Donde].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select distinct I.Articulo, I.Orden, I.Fechaord, I.Clave, I.Certificado1, I.Estado1, I.Informe, I.Cantidad, I.fecha, O.Fecha2, O.OrdFecha2 , O.Proveedor, L.Marca, L.Liberada, L.Liberadaant, L.Laudo, L.Devuelta, L.Devueltaant, P.TipoProv  from Informe I join Orden O on I.Orden = o.Orden and I.Articulo = O.Articulo LEFT join Laudo L on  L.Informe = I.Informe and I.Articulo = L.Articulo join Proveedor P on P.TipoProv = "+ Tipo +" where I.fechaord >= " + Desde + " and I.Fechaord <= " + Hasta + " order by O.Proveedor";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtInforme.Load(dataReader);

                }
                return dtInforme;
            }
        }

        public DataTable ListaInformeProve(int Desde, int Hasta, string Donde, int Tipo, string Prove)
        {
            DataTable dtInformeProve = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[Donde].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select distinct I.Clave, I.Articulo, A.Descripcion as DesArticulo, I.Orden, I.Fechaord,  I.Certificado1, I.Estado1, I.Informe, I.Cantidad, I.fecha, O.Fecha2, O.OrdFecha2 , O.Proveedor, L.Marca, L.Liberada, L.Liberadaant, L.Laudo, L.Devuelta, L.Devueltaant, P.TipoProv  from Informe I join Orden O on I.Orden = o.Orden and I.Articulo = O.Articulo LEFT join Laudo L on  L.Informe = I.Informe and I.Articulo = L.Articulo join Proveedor P on P.TipoProv = " + Tipo + " LEFT OUTER JOIN Articulo A ON A.Codigo = I.Articulo where I.fechaord >= " + Desde + " and I.Fechaord <= " + Hasta + "and O.Proveedor = '" + Prove + "' AND (L.Liberada <> 0 OR L.Devuelta <> 0)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtInformeProve.Load(dataReader);

                }
                return dtInformeProve;
            }
        }

        public DataTable ListaInformeProveNum(int Desde, int Hasta, string Donde, int Tipo, Int64 Prove)
        {
            DataTable dtInformeProve = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings[Donde].ConnectionString))
            {
                cnx.Open();
                string sqlQuery = "select distinct I.Articulo, I.Orden, I.Fechaord, I.Clave, I.Certificado1, I.Estado1, I.Informe, I.Cantidad, I.fecha, O.Fecha2, O.OrdFecha2 , O.Proveedor, L.Marca, L.Liberada, L.Liberadaant, L.Laudo, L.Devuelta, L.Devueltaant, P.TipoProv  from Informe I join Orden O on I.Orden = o.Orden and I.Articulo = O.Articulo LEFT join Laudo L on  L.Informe = I.Informe and I.Articulo = L.Articulo join Proveedor P on P.TipoProv = " + Tipo + " where I.fechaord >= " + Desde + " and I.Fechaord <= " + Hasta + "and O.Proveedor = " + Prove;
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtInformeProve.Load(dataReader);

                }
                return dtInformeProve;
            }
        }

    }
}
