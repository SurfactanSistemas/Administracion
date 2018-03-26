using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

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

        

        public System.Data.DataTable Lista()
        {
            return _EvaTransDAL.Lista();
        }

        public System.Data.DataTable ListaListaProveFecha(string Desde, string Hasta, string Proveedor)
        {
            return _EvaTransDAL.ListaProveFecha(Desde, Hasta, Proveedor);
        }
    }
}
