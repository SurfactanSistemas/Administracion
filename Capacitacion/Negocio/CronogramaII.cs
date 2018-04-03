using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassConexion;
using System.Data;

namespace Negocio
{
    public class CronogramaII : IRepoMetodos<CronogramaII>
    {
        string Clave;
        public Legajo Legajo;
        public List<Curso> Cursos { get; set; }
        public Tema Tema { get; set; }    
        public  string Año { get; set; }


        public int Curso { get; set; }

        public string Descripcion { get; set; }

        public int Personas { get; set; }

        public float Horas { get; set; }

        public float HorasRealizadas { get; set; }

        public string Mes1 { get; set; }

        public string Mes2 { get; set; }

        public string Mes3 { get; set; }

        public string Mes4 { get; set; }

        public string Mes5 { get; set; }

        public string Mes6 { get; set; }

        public string Mes7 { get; set; }

        public string Mes8 { get; set; }

        public string Mes9 { get; set; }

        public string Mes10 { get; set; }

        public string Mes11 { get; set; }

        public string Mes12 { get; set; }

        public void Eliminar(string ano)
        {
            Conexion repo = new Conexion();
            string consulta = "delete CronogramaII where  Ano = " + ano;
            repo.Eliminar(consulta);
        }

        public object BuscarUnoPorAño(string p)
        {
            ClassConexion.Conexion repo = new ClassConexion.Conexion();

            //string consulta = "select curso,count(*) as Personas,sum(horas) as Horas ,sum(Realizado) as Cursadas,"
            //+ "(sum(horas) -sum(Realizado)) as Resta  from cronograma where  ano = " + p + " group by curso order by curso asc";

            string consulta = "select Cr.Curso, C.Descripcion,Cr.Personas, Cr.Horas, Cr.HorasRealizado," +
                " (Cr.Horas - Cr.HorasRealizado) as Resta  ,Mes1, Mes2, Mes3, Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12" +
                " from CronogramaII Cr inner join Curso C on C.Codigo = Cr.Curso  where ano = " + p;

            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable ListarTodos()
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

                var clave1 = this.Año.ToString().PadLeft(4, '0');
                var clave2 = this.Curso.ToString().PadLeft(4, '0');

                var horas = this.Horas.ToString().Replace(",", ".");
                var realizado = this.HorasRealizadas.ToString().Replace(",", ".");
                float porce = (this.HorasRealizadas * 100) / this.Horas;

                var procentaje = !float.IsNaN(porce) ? porce.ToString().Replace(",", ".") : "0";                

                string consulta = "insert into cronogramaII (Clave,Ano,Curso,Personas,Horas,HorasRealizado,Porce," +
                " Mes1, Mes2,Mes3,Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12) " +
                "values ('" + clave1 + clave2 + "', " + Año + ", " + Curso + "," + Personas + ", " + horas + ", "
                + realizado + ", " + procentaje + ", '" + Mes1 + "', '" + Mes2 + "', '" + Mes3 + "', " +
                " '" + Mes4 + "', '" + Mes5 + "','" + Mes6 + "','" + Mes7 + "','" + Mes8 + "','" + Mes9 + "', " +
                "'" + Mes10 + "','" + Mes11 + "','" + Mes12 + "')";

                repo.Agregar(consulta);
        }

        public CronogramaII BuscarUno(string IdAModificar)
        {
            throw new NotImplementedException();
        }

        public void Modificar(CronogramaII t)
        {
            throw new NotImplementedException();
        }
    }
}
