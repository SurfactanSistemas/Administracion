using System.Data;
using AccesoADatos;

namespace Logica_Negocio
{
    public class EvaGeneralBOL
    {
        private EvaGeneralDAL _EvaGeneral = new EvaGeneralDAL();

        public void Eliminar(string Clave)
        {
            _EvaGeneral.Eliminar(Clave);
        }

        public int Ultimo()
        {
            return _EvaGeneral.Ultimo();
        }

        public DataTable ListaGen()
        {
            return _EvaGeneral.ListaGen();
        }

        public DataTable ListaGenUltimos()
        {
            return _EvaGeneral.ListaGenUltimos();
        }

        static public string ObtenerObservaciones(string Clave)
        {
            return (new EvaGeneralDAL()).ObtenerObservaciones(Clave);
        }
    }
}
