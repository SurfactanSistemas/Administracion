using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

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

        public System.Data.DataTable Lista()
        {
            return _ChoferDAL.Lista();
        }

        public System.Data.DataTable ListaProve(string Prove)
        {
            return _ChoferDAL.ListaProve(Prove);
        }

        public System.Data.DataTable ListaFecha(string Desde, string Hasta)
        {
            return _ChoferDAL.ListaFecha(Desde, Hasta);
        }
    }
}
