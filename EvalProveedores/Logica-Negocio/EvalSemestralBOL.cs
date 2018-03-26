using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

namespace Logica_Negocio
{
    public class EvalSemestralBOL
    {

        private EvalSemestralDAL _EvaSemDAL = new EvalSemestralDAL();

        public System.Data.DataTable ListaInforme(int Desde, int Hasta, string Donde, int Tipo)
        {
            return _EvaSemDAL.ListaInforme(Desde, Hasta, Donde, Tipo);
        }

        public System.Data.DataTable ListaInformeProve(int Desde, int Hasta, string Donde, int Tipo, string Prove)
        {
            return _EvaSemDAL.ListaInformeProve(Desde, Hasta, Donde, Tipo, Prove);
        }

        public System.Data.DataTable ListaInformeProveNum(int Desde, int Hasta, string Donde, int Tipo, Int64 Prove)
        {
            return _EvaSemDAL.ListaInformeProveNum(Desde, Hasta, Donde, Tipo, Prove);
        }
    }
}
