using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassConexion;
using System.Data;

namespace Negocio
{
    public class Responsable :IRepoMetodos<Responsable>
    {
        public int Codigo;

        public string Descripcion;

        public System.Data.DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "select * from ResponsableSac order by Codigo";
            return repo.Listar(consulta);
        }

        public int ObtenerUltimoId()
        {
            throw new NotImplementedException();
        }

        public void Agregar()
        {
            throw new NotImplementedException();
        }

        public Responsable BuscarUno(string IdAModificar)
        {
            Conexion Repo = new Conexion();
            DataTable DT = Repo.BuscarUno("select * from ResponsableSac where Codigo = " + IdAModificar);
            Responsable R = new Responsable();

            if (DT.Rows.Count > 0)
            {
                R.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                R.Descripcion = DT.Rows[0]["Descripcion"].ToString();
            }
            else
            {
                R.Codigo = int.Parse(IdAModificar);
                R.Descripcion = "";
            }

            return R;
        }

        public void Modificar(Responsable t)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string IdAEliminar)
        {
            throw new NotImplementedException();
        }
    }
}
