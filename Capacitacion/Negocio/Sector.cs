using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassConexion;
using System.Data;

namespace Negocio
{

    public class Sector : IRepoMetodos<Sector>
    {
        public int Codigo;

        public string Descripcion;


        public System.Data.DataTable ListarTodosCodigoDescripcion()
        {
            Conexion repo = new Conexion();
            string consulta = "select Codigo, Descripcion from Sector order by Codigo asc";
            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Sector order by Codigo asc";
            return repo.Listar(consulta);
        }

        public int ObtenerUltimoId()
        {
            Conexion repo = new Conexion();
            string valor = repo.TraerSectorMax();
            return int.Parse(valor);
        }

        public void Agregar()
        {
            Conexion repo = new Conexion();
            string consulta = "insert into Sector (Codigo,Descripcion) values (" + Codigo + ",'" + Descripcion + "')";
            repo.Agregar(consulta);
        }

        public Sector BuscarUno(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT Codigo, Descripcion FROM Sector WHERE Codigo = " + IdAModificar;
            DataTable DT = repo.BuscarUno(consulta);
            Sector sec = new Sector();

            if (DT.Rows.Count > 0) {             
                sec.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                sec.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                sec.Descripcion = sec.Descripcion.Trim();
            }

            return sec;
        }

        public void Modificar(Sector sector)
        {
            Conexion repo = new Conexion();
            string consulta = "update Sector set Descripcion = '" + sector.Descripcion + "' where Codigo = " + sector.Codigo;
            repo.Modificar(consulta);
        }

        public void Eliminar(string IdAEliminar)
        {
            Conexion repo = new Conexion();
            string consulta = "delete Sector where Codigo = " + IdAEliminar;
            repo.Eliminar(consulta);
        }
    }
}
