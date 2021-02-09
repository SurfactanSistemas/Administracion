using System.Data;
using ClassConexion;

namespace Negocio
{
    public class Tema : IRepoMetodos<Tema>
    {
        public int Codigo;
        public string Descripcion;
        public string TemaI;
        public string TemaII;
        public string TemaIII;
        public string Responsable;
        public int? Horas;
        public int Tipo;        
        public Responsable ResponsableII;
        public Responsable ResponsableIII;
        public int ResponsableIV;

        public string Deseable;
        public string Necesaria;
        public string Estado;
        public object Observacion;
        public string EstadoCurso;
        public int EstaCurso;
        
        public DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT * FROM Curso WHERE Codigo > 0 ORDER BY Codigo";
            return repo.Listar(consulta);
        }

        public DataTable ListarTodosPrincipal()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT Codigo, Descripcion, TemaI, TemaII, TemaIII, Responsable, Horas, Tipo, ResponsableII, ResponsableIII, ResponsableIV FROM Curso WHERE Codigo > 0 ORDER BY Codigo";
            return repo.Listar(consulta);
        }

        public int ObtenerUltimoId()
        {
            Conexion repo = new Conexion();
            string consulta = "select max(codigo) + 1 from curso";
            int valor = int.Parse(repo.TraerUltimoId(consulta));
            return valor;
        }

        public void Agregar()
        {
            Conexion repo = new Conexion();

            string consulta = "insert into curso" +
            "(Codigo,Descripcion,TemaI,TemaII,TemaIII,Responsable,Tipo,ResponsableII,ResponsableIII) values " +
            "("+Codigo+",'"+Descripcion+"','"+TemaI+"','"+TemaII+"','"+TemaIII+"','"+Responsable+"'" +
            ","+Tipo+","+ResponsableII.Codigo+","+ResponsableIII.Codigo+")";  
          
            repo.Agregar(consulta);
        }

        public Tema BuscarUno(string IdAModificar)
        {
                Conexion repo = new Conexion();
                string consulta = "select * from Curso where Codigo = " + IdAModificar;
                DataTable DT = repo.BuscarUno(consulta);
                Tema obj = new Tema();

                if (DT.Rows.Count > 0) { 
                //lleno el objeto
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.TemaI = DT.Rows[0]["TemaI"].ToString();
                obj.TemaII = DT.Rows[0]["TemaII"].ToString();
                obj.TemaIII = DT.Rows[0]["TemaIII"].ToString();
                obj.Responsable = DT.Rows[0]["Responsable"].ToString();
                int  prueba = 0;
                int.TryParse(DT.Rows[0]["Horas"].ToString(),out prueba);
                if (prueba == 0) obj.Horas = null;
                else { obj.Horas = prueba; }
                    Responsable R1 = new Responsable
                    {
                        Codigo = int.Parse(DT.Rows[0]["ResponsableII"].ToString())
                    };
                    R1 = R1.BuscarUno(R1.Codigo.ToString());

                    Responsable R2 = new Responsable
                    {
                        Codigo = int.Parse(DT.Rows[0]["ResponsableIII"].ToString())
                    };
                    R2 = R2.BuscarUno(R2.Codigo.ToString());
           
                //obj.ResponsableII = int.Parse(DT.Rows[0]["ResponsableII"].ToString());
                //obj.ResponsableIII = int.Parse(DT.Rows[0]["ResponsableIII"].ToString());

                obj.ResponsableII = R1;
                obj.ResponsableIII = R2;

                obj.Tipo = int.Parse(DT.Rows[0]["Tipo"].ToString());
            }
            return obj;
        }

        public Tema BuscarUno_Tema(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Curso where Codigo = " + IdAModificar;
            DataTable DT = repo.BuscarUno(consulta);
            Tema obj = new Tema();

            if (DT.Rows.Count > 0)
            {
                //lleno el objeto
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                //obj.TemaI = DT.Rows[0]["TemaI"].ToString();
                //obj.TemaII = DT.Rows[0]["TemaII"].ToString();
                //obj.TemaIII = DT.Rows[0]["TemaIII"].ToString();
                //obj.Responsable = DT.Rows[0]["Responsable"].ToString();
                //int prueba = 0;
                //int.TryParse(DT.Rows[0]["Horas"].ToString(), out prueba);
                //if (prueba == 0) obj.Horas = null;
                //else { obj.Horas = prueba; }
                //Responsable R1 = new Responsable();
                //R1.Codigo = int.Parse(DT.Rows[0]["ResponsableII"].ToString());
                //R1 = R1.BuscarUno(R1.Codigo.ToString());

                //Responsable R2 = new Responsable();
                //R2.Codigo = int.Parse(DT.Rows[0]["ResponsableIII"].ToString());
                //R2 = R2.BuscarUno(R2.Codigo.ToString());

                ////obj.ResponsableII = int.Parse(DT.Rows[0]["ResponsableII"].ToString());
                ////obj.ResponsableIII = int.Parse(DT.Rows[0]["ResponsableIII"].ToString());

                //obj.ResponsableII = R1;
                //obj.ResponsableIII = R2;

                //obj.Tipo = int.Parse(DT.Rows[0]["Tipo"].ToString());
            }
            return obj;
        }

        public Tema BuscarUno(string IdAModificar, int renglon)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Curso where Codigo = " + IdAModificar;
            DataTable DT = repo.BuscarUno(consulta);
            Tema obj = new Tema();

            if (DT.Rows.Count > 0)
            {
                //lleno el objeto
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.TemaI = DT.Rows[0]["TemaI"].ToString();
                obj.TemaII = DT.Rows[0]["TemaII"].ToString();
                obj.TemaIII = DT.Rows[0]["TemaIII"].ToString();
                obj.Responsable = DT.Rows[0]["Responsable"].ToString();
                int prueba = 0;
                int.TryParse(DT.Rows[0]["Horas"].ToString(), out prueba);
                if (prueba == 0) obj.Horas = null;
                else { obj.Horas = prueba; }
                Responsable R1 = new Responsable
                {
                    Codigo = int.Parse(DT.Rows[0]["ResponsableII"].ToString())
                };
                R1 = R1.BuscarUno(R1.Codigo.ToString());

                Responsable R2 = new Responsable
                {
                    Codigo = int.Parse(DT.Rows[0]["ResponsableIII"].ToString())
                };
                R2 = R2.BuscarUno(R2.Codigo.ToString());

                //obj.ResponsableII = int.Parse(DT.Rows[0]["ResponsableII"].ToString());
                //obj.ResponsableIII = int.Parse(DT.Rows[0]["ResponsableIII"].ToString());

                obj.ResponsableII = R1;
                obj.ResponsableIII = R2;

                obj.Tipo = int.Parse(DT.Rows[0]["Tipo"].ToString());
            }
            return obj;
        }

        public void Modificar(Tema tema)
        {
            Conexion repo = new Conexion();
            string consulta = "update curso" +
            " set Descripcion = '" + tema.Descripcion + "', TemaI = '" + tema.TemaI + "', TemaII = '" + tema.TemaII + "'," +
            "TemaIII = '" + tema.TemaIII + "', Responsable = '" + tema.Responsable + "', Tipo = " + tema.Tipo + ", " +
            "ResponsableII = '" + tema.ResponsableII.Codigo + "', ResponsableIII = '" + tema.ResponsableIII.Codigo + "'" +
            "where Codigo = " + tema.Codigo;
            repo.Modificar(consulta);
        }

        public void Eliminar(string IdAEliminar)
        {
            Conexion repo = new Conexion();
            string consulta = "delete Curso where Codigo = " + IdAEliminar;
            repo.Eliminar(consulta);
        }

        public int ObtenerUltimo(string tema)
        {
            Conexion repo = new Conexion();
            string consulta = "select max(tema) + 1 from Tema where Tema < 99 And curso =  " + tema;
            //string consulta = "select max(tema) + 1 from Tema where tema != 86";
            int valor = 0;
            int.TryParse(repo.TraerUltimoId(consulta), out valor);
            return valor;
        }

        public DataTable ListarTemas()
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Tema order by Tema asc";
            return repo.Listar(consulta);
        }

        public DataTable ListarTemasPlani()
        {
            Conexion repo = new Conexion();
            string consulta = "Select C.codigo, C.Descripcion from Curso C order by Codigo";
            return repo.Listar(consulta);
        }

        
    }
}
