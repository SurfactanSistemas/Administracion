using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Negocio;
using AccesoADatos;

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



        public System.Data.DataTable Lista()
        {
            return _EvaVariosDAL.Lista();
        }

        public System.Data.DataTable EvaServ(Int64 Prove, string Desde, string Hasta, int Tipo1, int Tipo2)
        {
            return _EvaVariosDAL.EvaServ(Prove, Desde, Hasta, Tipo1, Tipo2);
        }

    }
}

