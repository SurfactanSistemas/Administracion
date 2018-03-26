using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class TipoProveedorBOL
    {
        private TipoProveedorDAL _TipoProveDAL = new TipoProveedorDAL();

        public System.Data.DataTable Lista()
        {
            return _TipoProveDAL.Lista();
        }
    }
}
