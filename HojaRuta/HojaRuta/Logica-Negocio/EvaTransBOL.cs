using System.Data;
using AccesoADatos;
using Negocio;

namespace Logica_Negocio
{
    public class EvaTransBOL : EvaGeneralBOL
    {
        private EvaTransDAL _EvaTransDAL = new EvaTransDAL();

        public void Insertar(EvaluaTransp Eva)
        {
            _EvaTransDAL.Insertar(Eva);
        }

        public void Modificar(EvaluaTransp Eva)
        {
            _EvaTransDAL.Update(Eva);
        }

        

        public EvaluaTransp Find(string Clave)
        {
            return _EvaTransDAL.BuscarUno(Clave);
        }

        

        public DataTable Lista()
        {
            return _EvaTransDAL.Lista();
        }

        public DataTable ListaListaProveFecha(string Desde, string Hasta, string Proveedor)
        {
            return _EvaTransDAL.ListaProveFecha(Desde, Hasta, Proveedor);
        }
    }
}
