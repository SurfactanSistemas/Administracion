using System.Collections.Generic;
using System.Data;
using AccesoADatos;
using Negocio;

namespace Logica_Negocio
{
    public class ChoferBOL
    {
        private ChoferDAL _ChoferDAL = new ChoferDAL();

        public List<Chofer> Todos()
        {
            return _ChoferDAL.ListarTodos();
        }

        public void Insertar(Chofer chofer)
        {
            

            _ChoferDAL.Insertar(chofer);
        }

        public void Modificar(Chofer chofer)
        {
            _ChoferDAL.Update(chofer);
        }

        public void Eliminar(int  Codigo)
        {
            _ChoferDAL.Eliminar(Codigo);
        }

        public Chofer Find(int Codigo)
        {
           return _ChoferDAL.BuscarUno(Codigo);
            
            
        }

        public int Ultimo()
        {
            return _ChoferDAL.Ultimo();
        }

        public DataTable Lista()
        {
            return _ChoferDAL.Lista();
        }

        public DataTable ListaProve(string Prove)
        {
            return _ChoferDAL.ListaProve(Prove);
        }

        public DataTable ListaFecha(string Desde, string Hasta)
        {
            return _ChoferDAL.ListaFecha(Desde, Hasta);
        }
    }
}
