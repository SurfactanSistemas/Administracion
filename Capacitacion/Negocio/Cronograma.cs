using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassConexion;
using System.Data;

namespace Negocio
{
    public class Cronograma : IRepoMetodos<Cronograma>
    {
        string Clave;
        public Legajo Legajo;
        public List<Curso> Cursos { get; set; }


        public System.Data.DataTable ListarTodos()
        {

            throw new NotImplementedException();

        }

        public int ObtenerUltimoId()
        {
            throw new NotImplementedException();
        }

        public void Agregar()
        {
            Conexion repo = new Conexion();

            int renglon = 1;

            foreach (var item in this.Cursos)
	        {
                var clave1 = this.Legajo.Codigo.ToString().PadLeft(6, '0');
                var clave2 = this.Año.ToString().PadLeft(4, '0');
                var clave3 = renglon.ToString().PadLeft(2, '0');

                var horas = item.Horas.ToString().Replace(",", ".");
                var realizado = item.Realizado.ToString().Replace(",", ".");

		        string consulta = "insert into cronograma (Clave,Legajo,Ano,Renglon,Curso,Horas,Realizado," +
                " DesLegajo, Tema,DesTema) " +
                "values ('"+ clave1 +clave2+clave3 +"', "+Legajo.Codigo +", "+ Año +"," + renglon+ ", " + item.Curso_Id + ", "
                + horas + ", " + realizado + ", '" + Legajo.Descripcion + "', " + item.Tema + ",'' )";
                repo.Agregar(consulta);

                renglon++;
	        }

            
        }

        public Cronograma BuscarUno(string IdAModificar)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Cronograma t)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string IdAEliminar)
        {
            throw new NotImplementedException();
        }

        public DataTable BuscarUno(string p1, string p2)
        {
            ClassConexion.Conexion repo = new ClassConexion.Conexion();

            string consulta = "select Cr.Curso as Tema, C.Descripcion as DesTema, Cr.Tema as Curso, '' as DesCurso, Cr.Horas, Cr.Realizado" +
                                " from cronograma Cr inner join Curso C on C.Codigo = Cr.Curso " 
                                + " where Cr.legajo = "+p1+" and Cr.ano = " + p2;

            DataTable DT =  repo.BuscarUno(consulta);

            //Cronograma Cr = new Cronograma();
            //return Cr;

            return DT;
        }

        public Tema Tema { get; set; }
    
        public  string Año { get; set; }
        public void Eliminar(int p1, string p2)
        {
            Conexion repo = new Conexion();
            string consulta = "delete Cronograma where legajo = " + p1 + " and Ano = " + p2;
            repo.Eliminar(consulta);
        }

        

        public object BuscarPorAño(string p)
        {
            ClassConexion.Conexion repo = new ClassConexion.Conexion();

            string consulta = "select Cr.Curso,C.Descripcion,count(*) as Personas,sum(Cr.horas) as Horas ," + 
                " sum(Cr.Realizado) as HorasRealizado, (sum(Cr.horas) -sum(Cr.Realizado)) as Resta, 'N' as Mes1, " + 
                " '' as Mes2, '' as Mes3, '' as Mes4, '' as Mes5, " 
                + " '' as Mes6,'' as Mes7,'' as Mes8,'' as Mes9,'' as Mes10,'' as Mes11,'' as Mes12 " +
                " from cronograma Cr inner join Curso C on C.Codigo = Cr.Curso  where  ano = " + p +
                " group by curso,descripcion  order by curso asc";

            //string consulta = "select Cr.Curso, C.Descripcion,Cr.Personas, Cr.Horas, Cr.HorasRealizado," +
            //    " (Cr.Horas - Cr.HorasRealizado) as Resta  ,Mes1, Mes2, Mes3, Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12" +
            //    " from CronogramaII Cr inner join Curso C on C.Codigo = Cr.Curso  where ano = " + p;

            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public System.Data.DataTable ListarHorasRealizadas()
        {
            Conexion repo = new Conexion();
            string consulta = "select C.DesLegajo, C.Legajo, C.Realizado  from Cronograma C";
            return repo.Listar(consulta);
        }



        public System.Data.DataTable BuscarUnoCursada(int Año, int Legajo, int Curso)
        {
            ClassConexion.Conexion repo = new ClassConexion.Conexion();

            string consulta = "select * From Cronograma Cr where Cr.Ano = " + Año + " and Cr.Legajo = " + Legajo + " and Curso = " + Curso;


            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }


        //public void EliminarII(string ano)
        //{
        //    Conexion repo = new Conexion();
        //    string consulta = "delete CronogramaII where  Ano = " + ano;
        //    repo.Eliminar(consulta);
        //}
    }
}
