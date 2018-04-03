using System;
using System.Data;
using ClassConexion;

namespace Negocio
{
    public class Curso:IRepoMetodos<Curso>
    {
        public string Clave;
        public int? Tema;
        public string Descripcion;
        public string DescripcionCurso;
        public float? Horas;
        public int Curso_Id;

        public DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT T.Clave, T.Tema, C.Descripcion as CursoDesc, T.Descripcion, T.Curso, T.Horas FROM Tema T INNER JOIN Curso C ON C.Codigo = T.Curso WHERE T.Curso > 0 ORDER BY T.Clave";

            return repo.Listar(consulta);
        }

        public int ObtenerUltimoId()
        {
            throw new NotImplementedException();
        }

        public void Agregar()
        {
            Conexion repo = new Conexion();

            var clave2 = Curso_Id.ToString().PadLeft(4, '0');
            var clave1 = Tema.ToString().PadLeft(4, '0');
            var horas = Horas.ToString().Replace(",",".");
            

            string consulta = "insert into tema" +
            "(clave,Tema,Descripcion,Curso,Horas) values ('" + clave1 + clave2 + "'," + Curso_Id + ",'" + Descripcion + "'," + Tema + "," + horas + ")";

            repo.Agregar(consulta);
        }

        public Curso BuscarUno(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "select T.Clave, T.Tema, C.Descripcion as CursoDesc, T.Descripcion, T.Curso, T.Horas from Tema T inner join Curso C on C.Codigo = T.Curso where clave = '" + IdAModificar + "'";
            DataTable DT = repo.BuscarUno(consulta);
            Curso obj = new Curso();

            if (DT.Rows.Count > 0)
            {
                //lleno el objeto
                //obj.Clave = DT.Rows[0]["clave"].ToString();
                obj.Descripcion = DT.Rows[0][3].ToString();
                obj.Tema = int.Parse(DT.Rows[0][1].ToString());
                obj.DescripcionCurso = DT.Rows[0][2].ToString();
                obj.Curso_Id = int.Parse(DT.Rows[0][4].ToString());
                //obj.Horas = DT.Rows[0]["TemaIII"].ToString();

                float hora_parse = 0;
                float.TryParse(DT.Rows[0]["Horas"].ToString(), out hora_parse);
                if (hora_parse == 0) obj.Horas = null;
                else { obj.Horas = hora_parse; }

            }
            return obj;
        }

        public void Modificar(Curso t)
        {
            Conexion repo = new Conexion();

            var clave2 = t.Curso_Id.ToString().PadLeft(4, '0');
            var clave1 = t.Tema.ToString().PadLeft(4, '0');
            var horas = t.Horas.ToString().Replace(",",".");


            string consulta = "update tema set Descripcion = '" + t.Descripcion + "', Horas = " + horas + "where clave = '" + clave1+clave2 + "'";
            repo.Modificar(consulta);
        }

        public void Eliminar(string IdAEliminar)
        {
            Conexion repo = new Conexion();
            string consulta = "delete Tema where clave = " + IdAEliminar;
            repo.Eliminar(consulta);
        }

        public float Realizado { get; set; }



        public Curso BuscarUnoPorTema(string p1, string p2)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Tema where tema = " + p2 + " and Curso = " + p1;
            DataTable DT = repo.BuscarUno(consulta);
            Curso obj = new Curso();

            if (DT.Rows.Count > 0)
            {
                //lleno el objeto
                //obj.Clave = DT.Rows[0]["clave"].ToString();
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.Tema = int.Parse(DT.Rows[0]["Curso"].ToString());
                obj.Curso_Id = int.Parse(DT.Rows[0]["Tema"].ToString());
                //obj.Horas = DT.Rows[0]["TemaIII"].ToString();

                float hora_parse = 0;
                float.TryParse(DT.Rows[0]["Horas"].ToString(), out hora_parse);
                if (hora_parse == 0) obj.Horas = null;
                else { obj.Horas = hora_parse; }

            }
            return obj;
        }

        public DataTable ListarTodosListado()
        {
            Conexion repo = new Conexion();
            string consulta = "select C.Codigo, C.Descripcion, C.Responsable from Curso C where C.Codigo <> 0 order by Codigo asc";

            return repo.Listar(consulta);
        }

        public DataTable ListarPorResponsable(string Resp)
        {
            Conexion repo = new Conexion();
            string consulta = "select C.Codigo, C.Descripcion, C.Responsable from Curso C where C.Codigo <> 0 and C.Responsable = '" +Resp + "' order by Codigo asc";
 

            return repo.Listar(consulta);
        }

        public DataTable ListaPorTema(int Curso)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Tema where Curso = " + Curso;


            return repo.Listar(consulta);
        }
    }
}
