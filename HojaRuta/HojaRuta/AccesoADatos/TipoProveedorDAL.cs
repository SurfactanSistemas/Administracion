using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoADatos
{
    public class TipoProveedorDAL
    {

        public DataTable Lista()
        {
            DataTable dtTipoProve = new DataTable(); ;
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["SurfactanSA"].ConnectionString))
            {
                cnx.Open();

                string sqlQuery = "select * from TipoProv order by Descripcion";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    dtTipoProve.Load(dataReader);

                }
            }
            return dtTipoProve;
        }
    }
}
