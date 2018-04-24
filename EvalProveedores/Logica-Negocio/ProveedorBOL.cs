using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class ProveedorBOL
    {
        private ProveedorDAL _ProveedorDAL = new ProveedorDAL();

        public List<Proveedor> Todos()
        {
            return _ProveedorDAL.ListarTodos();
        }

        public System.Data.DataTable Lista()
        {
            return _ProveedorDAL.Lista();
        }

        public Proveedor Find(string Codigo)
        {
            return _ProveedorDAL.BuscarUno(Codigo);
        }

        public System.Data.DataTable ListaRubroFecha(string RubroDesde)
        {
            return _ProveedorDAL.Lista(RubroDesde);
        }

        public System.Data.DataTable ListaRubro(string RubroDesde)
        {
            return _ProveedorDAL.ListaRubro(RubroDesde);
        }

        public System.Data.DataTable ListaTipo(int Tipo)
        {
            return _ProveedorDAL.ListaPorTipo(Tipo);
        }

        public System.Data.DataTable ListaSinTipo()
        {
            return _ProveedorDAL.ListaSinTipo();
        }

        public void Modificar(Proveedor Prove, string Donde)
        {
            _ProveedorDAL.Update(Prove, Donde);
        }

        public void Inhabilitar (Proveedor Prove, string Donde)
        {
            _ProveedorDAL.Inhabilitar(Prove, Donde);
        }
    }
}
