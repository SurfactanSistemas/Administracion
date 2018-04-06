using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class EvaGeneralBOL
    {
        private EvaGeneralDAL _EvaGeneral = new EvaGeneralDAL();

        public void Eliminar(string Clave)
        {
            _EvaGeneral.Eliminar(Clave);
        }

        public int Ultimo()
        {
            return _EvaGeneral.Ultimo();
        }

        public System.Data.DataTable ListaGen()
        {
            return _EvaGeneral.ListaGen();
        }

        public System.Data.DataTable ListaGenUltimos()
        {
            return _EvaGeneral.ListaGenUltimos();
        }

        static public string ObtenerObservaciones(string Clave)
        {
            return (new EvaGeneralDAL()).ObtenerObservaciones(Clave);
        }
    }
}
