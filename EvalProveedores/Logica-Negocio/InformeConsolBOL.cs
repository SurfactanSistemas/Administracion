using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class InformeConsolBOL
    {
        private InformeConsolDAL _InformeDAL = new InformeConsolDAL();

        public System.Data.DataTable Lista()
        {
            return _InformeDAL.Lista();
        }
    }
}
