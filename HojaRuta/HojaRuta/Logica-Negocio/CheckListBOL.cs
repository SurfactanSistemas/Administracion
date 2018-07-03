using System.Data;
using AccesoADatos;

namespace Logica_Negocio
{
    public class CheckListBOL
    {
        private HojaRutaDAL _HojaRutaDAL = new HojaRutaDAL();

        public DataTable ListaFecha(string Desde, string Hasta)
        {
            return _HojaRutaDAL.ListaFecha(Desde, Hasta);
        }
    }
}
