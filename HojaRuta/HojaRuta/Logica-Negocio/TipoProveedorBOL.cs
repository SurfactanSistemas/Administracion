using System.Data;
using AccesoADatos;

namespace Logica_Negocio
{
    public class TipoProveedorBOL
    {
        private TipoProveedorDAL _TipoProveDAL = new TipoProveedorDAL();

        public DataTable Lista()
        {
            return _TipoProveDAL.Lista();
        }
    }
}
