using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class EvaluaGen
    {

        string _Clave;

        public string Clave
        {
            set { _Clave = value; }
            get { return _Clave; }
        }

        string _Proveedor;

        public string Proveedor
        {
            set { _Proveedor = value; }
            get { return _Proveedor; }
        }

        int _Mes;

        public int Mes
        {
            set { _Mes = value; }
            get { return _Mes; }
        }

        int _Año;

        public int Año
        {
            set { _Año = value; }
            get { return _Año; }
        }

        double _PromedioTot;

        public double PromedioTot
        {
            set { _PromedioTot = value; }
            get { return _PromedioTot; }
        }

        double _Promedio11;

        public double Promedio11
        {
            set { _Promedio11 = value; }
            get { return _Promedio11; }
        }

        double _Promedio22;

        public double Promedio22
        {
            set { _Promedio22 = value; }
            get { return _Promedio22; }
        }

        double _Promedio33;

        public double Promedio33
        {
            set { _Promedio33 = value; }
            get { return _Promedio33; }
        }

        string _Observ;

        public string Observ
        {
            set { _Observ = value; }
            get { return _Observ; }
        }

        string _Periodo;

        public string Periodo
        {
            set { _Periodo = value; }
            get { return _Periodo; }
        }

        int _Tipo;

        public int Tipo
        {
            set { _Tipo = value; }
            get { return _Tipo; }
        }

    }
}
