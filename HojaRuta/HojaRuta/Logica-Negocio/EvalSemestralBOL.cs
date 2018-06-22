using System;
using System.Data;
using AccesoADatos;

namespace Logica_Negocio
{
    public class EvalSemestralBOL
    {

        private EvalSemestralDAL _EvaSemDAL = new EvalSemestralDAL();

        public DataTable ListaInforme(int Desde, int Hasta, string Donde, int Tipo)
        {
            return _EvaSemDAL.ListaInforme(Desde, Hasta, Donde, Tipo);
        }

        public DataTable ListaInformeProve(string Desde, string Hasta, string Donde, int Tipo, string Prove)
        {
            return _EvaSemDAL.ListaInformeProve(int.Parse(Desde), int.Parse(Hasta), Donde, Tipo, Prove);
        }

        public DataTable ListaInformeProve(int Desde, int Hasta, string Donde, int Tipo, string Prove)
        {
            return _EvaSemDAL.ListaInformeProve(Desde, Hasta, Donde, Tipo, Prove);
        }

        public DataTable ListaInformeProveNum(int Desde, int Hasta, string Donde, int Tipo, Int64 Prove)
        {
            return _EvaSemDAL.ListaInformeProveNum(Desde, Hasta, Donde, Tipo, Prove);
        }
    }
}
