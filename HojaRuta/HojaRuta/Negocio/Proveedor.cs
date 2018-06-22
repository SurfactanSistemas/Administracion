namespace Negocio
{
    public class Proveedor
    {
        string _Codigo;

        public string Codigo
        {
            set { _Codigo = value; }
            get { return _Codigo; }
        }

        string _Nombre;

        public string Descripcion
        {
            set { _Nombre = value; }
            get { return _Nombre; }
        }

        int _Estado;

        public int Estado
        {
            set { _Estado = value; }
            get { return _Estado; }
        }

        string _Observac;

        public string Observac
        {
            set { _Observac = value; }
            get { return _Observac; }
        }

        int _Categoria1;

        public int Categoria1
        {
            set { _Categoria1 = value; }
            get { return _Categoria1; }
        }

        int _Categoria2;

        public int Categoria2
        {
            set { _Categoria2 = value; }
            get { return _Categoria2; }
        }

        string _FechaCat;

        public string FechaCat
        {
            set { _FechaCat = value; }
            get { return _FechaCat; }
        }
    }
}
