using System.Data;
using AccesoADatos;

namespace Logica_Negocio
{
    public class InformeConsolBOL
    {
        private InformeConsolDAL _InformeDAL = new InformeConsolDAL();

        public DataTable Lista()
        {
            return _InformeDAL.Lista();
        }

        public DataTable Lista(string WDesde, string WHasta)
        {
            return _InformeDAL.Lista(WDesde, WHasta);
        }
    }
}
