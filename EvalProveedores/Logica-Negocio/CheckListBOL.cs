using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class CheckListBOL
    {
        private HojaRutaDAL _HojaRutaDAL = new HojaRutaDAL();

        public System.Data.DataTable ListaFecha(string Desde, string Hasta)
        {
            return _HojaRutaDAL.ListaFecha(Desde, Hasta);
        }
    }
}
