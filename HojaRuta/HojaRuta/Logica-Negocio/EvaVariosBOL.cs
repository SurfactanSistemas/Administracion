using System;
using System.Data;
using AccesoADatos;
using Negocio;

namespace Logica_Negocio
{
    public class EvaVariosBOL : EvaGeneralBOL
    {
        private EvaluaVariosDAL _EvaVariosDAL = new EvaluaVariosDAL();

        public void Insertar(EvaluaVarios Eva)
        {
            _EvaVariosDAL.Insertar(Eva);
        }

        public void Modificar(EvaluaVarios Eva)
        {
            _EvaVariosDAL.Update(Eva);
        }



        public EvaluaVarios Find(string Clave)
        {
            return _EvaVariosDAL.BuscarUno(Clave);
        }



        public DataTable Lista()
        {
            return _EvaVariosDAL.Lista();
        }

        public DataTable EvaServ(Int64 Prove, string Desde, string Hasta, int Tipo1, int Tipo2)
        {
            return _EvaVariosDAL.EvaServ(Prove, Desde, Hasta, Tipo1, Tipo2);
        }

    }
}

