using System.Collections.Generic;
using System.Data;
using AccesoADatos;
using Negocio;

namespace Logica_Negocio
{
    public class CamionBOL
    {
        private CamionDAL _CamionDAL = new CamionDAL();

        public List<Camion> Todos()
        {
            return _CamionDAL.ListarTodos();
        }

        public void Insertar(Camion camion)
        {
            _CamionDAL.Insertar(camion);
        }

        public void Modificar(Camion camion)
        {
            _CamionDAL.Update(camion);
        }

        public void Eliminar(int Codigo)
        {
            _CamionDAL.Eliminar(Codigo);
        }

        public Camion Find(int Codigo)
        {
            return _CamionDAL.BuscarUno(Codigo);
        }

        public int Ultimo()
        {
            return _CamionDAL.Ultimo();
        }

        public DataTable Lista()
        {
            return _CamionDAL.Lista();
        }

        public DataTable ListaProve(string Prove)
        {
            return _CamionDAL.ListaProve(Prove);
        }

        public DataTable ListaFecha(string Desde, string Hasta)
        {
            return _CamionDAL.ListaFecha(Desde, Hasta);
        }
    }
}
