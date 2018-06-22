using System.Collections.Generic;
using System.Data;
using AccesoADatos;
using Negocio;

namespace Logica_Negocio
{
    public class ProveedorBOL
    {
        private ProveedorDAL _ProveedorDAL = new ProveedorDAL();

        public List<Proveedor> Todos()
        {
            return _ProveedorDAL.ListarTodos();
        }

        public DataTable Lista()
        {
            return _ProveedorDAL.Lista();
        }

        public Proveedor Find(string Codigo)
        {
            return _ProveedorDAL.BuscarUno(Codigo);
        }

        public DataTable ListaRubroFecha(string RubroDesde)
        {
            return _ProveedorDAL.Lista(RubroDesde);
        }

        public DataTable ListaRubro(string RubroDesde)
        {
            return _ProveedorDAL.ListaRubro(RubroDesde);
        }

        public DataTable ListaTipo(int Tipo)
        {
            return _ProveedorDAL.ListaPorTipo(Tipo);
        }

        public DataTable ListaSinTipo()
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
