using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassConexion;

namespace Negocio
{
    public class Terminado
    {
        Conexion co = new Conexion();
        int _Clase;
        int _Naciones;
        int _Intervencion;

        public int Naciones
        {
            set { _Naciones = value; }
            get { return _Naciones; }
        }

        public int Intervencion
        {
            set { _Intervencion = value; }
            get { return _Intervencion; }
        }

        public int Clase
        {
            set { _Clase = value; }
            get { return _Clase; }
        }

        public DataRow ListarPeligroso(string codigo)
        {
            return co.TraerPeligroso(codigo);
        }
    }
}
