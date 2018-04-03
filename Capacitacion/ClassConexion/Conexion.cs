using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ClassConexion
{
    public class Conexion
    {
        SqlConnection conexion;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable DT = new DataTable();

        string CS = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;

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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
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
            AbrirConexion();
            string consulta = "select max(Codigo) + 1 as Id from Sector where codigo != '1000'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            AbrirConexion();
            cmd.Connection = conexion;
            string value = System.Convert.ToString(cmd.ExecuteScalar());

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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            AbrirConexion();
            cmd.Connection = conexion;

            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }
        #endregion

        public void Eliminar(string consulta)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            AbrirConexion();
            cmd.Connection = conexion;
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();

            CerrarConexion();
        }

        public string TraerUltimoId(string consulta)
        {
            AbrirConexion();            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            AbrirConexion();
            cmd.Connection = conexion;
            string value = System.Convert.ToString(cmd.ExecuteScalar());
            
            CerrarConexion();

            return value;
        }

        public string TraerVersionMax(string consulta)
        {
            AbrirConexion();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            AbrirConexion();
            cmd.Connection = conexion;
            string value = System.Convert.ToString(cmd.ExecuteScalar());

            CerrarConexion();

            return value; 
        }
    }
}
