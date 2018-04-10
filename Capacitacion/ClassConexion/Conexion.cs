using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClassConexion
{
    public class Conexion
    {
        SqlConnection conexion;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable DT = new DataTable();

        //todo lo comun
        public void AbrirConexion()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString);
            conexion.Open();
        }

        //cs modificada
        public void AbrirConexion(string cs)
        {
            conexion = new SqlConnection(cs);
            conexion.Open();
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

       

        #region Sector

        public void Agregar(string consulta)
        {
            SqlCommand cmd = new SqlCommand {CommandType = CommandType.Text};
            AbrirConexion();
            cmd.Connection = conexion;
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();
            CerrarConexion();
        }

        public DataTable Listar(string consulta)
        {
            AbrirConexion();
            
            adapter.SelectCommand = new SqlCommand(consulta, conexion);
            DT.Clear();
            adapter.Fill(DT);
            adapter.SelectCommand = new SqlCommand("");
            CerrarConexion();
            return DT;
        }

        public string TraerSectorMax()
        {
            //AbrirConexion();
            string consulta = "select max(Codigo) + 1 as Id from Sector where codigo != '1000'";
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = consulta
            };
            AbrirConexion();
            cmd.Connection = conexion;
            string value = Convert.ToString(cmd.ExecuteScalar());

            CerrarConexion();

            return value;
        }

        public DataTable BuscarUno(string consulta)
        {
            AbrirConexion();
            
            adapter.SelectCommand = new SqlCommand(consulta, conexion);
            DT.Clear();
            adapter.Fill(DT);
            adapter.SelectCommand = new SqlCommand("");
            CerrarConexion();

            return DT;
        }

        public void Modificar(string consulta)
        {
            SqlCommand cmd = new SqlCommand {CommandType = CommandType.Text};
            AbrirConexion();
            cmd.Connection = conexion;

            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }
        #endregion

        public void Eliminar(string consulta)
        {
            SqlCommand cmd = new SqlCommand {CommandType = CommandType.Text};
            AbrirConexion();
            cmd.Connection = conexion;
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }

        public string TraerValor(string consulta, object valorDefecto = null)
        {
            //AbrirConexion();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = consulta
            };
            AbrirConexion();
            cmd.Connection = conexion;
            string value = Convert.ToString(cmd.ExecuteScalar());

            CerrarConexion();

            return value;
        }

        public string TraerUltimoId(string consulta)
        {
            //AbrirConexion();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = consulta
            };
            AbrirConexion();
            cmd.Connection = conexion;
            string value = Convert.ToString(cmd.ExecuteScalar());
            
            CerrarConexion();

            return value;
        }

        public string TraerVersionMax(string consulta)
        {
            //AbrirConexion();
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = consulta
            };
            AbrirConexion();
            cmd.Connection = conexion;
            string value = Convert.ToString(cmd.ExecuteScalar());

            CerrarConexion();

            return value; 
        }
    }
}
