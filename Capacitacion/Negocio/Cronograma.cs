using System;
using System.Collections.Generic;
using System.Data;
using ClassConexion;

namespace Negocio
{
    public class Cronograma : IRepoMetodos<Cronograma>
    {
        string Clave;
        public Legajo Legajo;
        public List<Curso> Cursos { get; set; }


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

            int renglon = 1;

            foreach (var item in Cursos)
	        {
                var clave1 = Legajo.Codigo.ToString().PadLeft(6, '0');
                var clave2 = Año.PadLeft(4, '0');
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
            Conexion repo = new Conexion();

            string consulta = "select Cr.Curso as Tema, C.Descripcion as DesTema, Cr.Tema as Curso, t.Descripcion as DesCurso, Cr.Horas, Cr.Realizado" +
                                " from cronograma Cr inner join Curso C on C.Codigo = Cr.Curso LEFT OUTER JOIN Tema t ON cr.Curso = t.Curso AND Cr.Tema = t.Tema" 
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
            Conexion repo = new Conexion();

            //string consulta = "select Cr.Curso,C.Descripcion,count(*) as Personas,sum(Cr.horas) as Horas ," + 
            //    " sum(Cr.Realizado) as HorasRealizado, (sum(Cr.horas) -sum(Cr.Realizado)) as Resta, 'N' as Mes1, " + 
            //    " '' as Mes2, '' as Mes3, '' as Mes4, '' as Mes5, " 
            //    + " '' as Mes6,'' as Mes7,'' as Mes8,'' as Mes9,'' as Mes10,'' as Mes11,'' as Mes12 " +
            //    " from cronograma Cr inner join Curso C on C.Codigo = Cr.Curso  where  ano = " + p +
            //    " group by curso,descripcion  order by curso asc";

            string consulta = "select Cr.Curso,C.Descripcion,count(*) as Personas,sum(Cr.horas) as Horas," +
                              " sum(Cr.Realizado) as HorasRealizado, Resta = CASE WHEN (sum(Cr.horas) -sum(Cr.Realizado)) > 0 THEN (sum(Cr.horas) -sum(Cr.Realizado)) ELSE 0 END," +
                              " Cr2.Mes1,  Cr2.Mes2, Cr2.Mes3, Cr2.Mes4, Cr2.Mes5, Cr2.Mes6, Cr2.Mes7, Cr2.Mes8, " +
                              " Cr2.Mes9,Cr2.Mes10,Cr2.Mes11,Cr2.Mes12  from cronograma Cr LEFT OUTER join Curso C on C.Codigo = Cr.Curso " +
                              " LEFT OUTER JOIN CronogramaII Cr2 ON Cr.Ano = Cr2.Ano AND Cr.Curso = Cr2.Curso where Cr.ano = '" + p + "' " +
                              " group by Cr.curso, C.descripcion, Cr2.Mes1, Cr2.Mes2, Cr2.Mes3, Cr2.Mes4, Cr2.Mes5, Cr2.Mes6, Cr2.Mes7, Cr2.Mes8, " +
                              " Cr2.Mes9, Cr2.Mes10, Cr2.Mes11, Cr2.Mes12  order by Cr.curso asc";

            //string consulta = "select Cr.Curso, C.Descripcion,Cr.Personas, Cr.Horas, Cr.HorasRealizado," +
            //    " (Cr.Horas - Cr.HorasRealizado) as Resta  ,Mes1, Mes2, Mes3, Mes4,Mes5,Mes6,Mes7,Mes8,Mes9,Mes10,Mes11,Mes12" +
            //    " from CronogramaII Cr inner join Curso C on C.Codigo = Cr.Curso  where ano = " + p;

            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable ListarHorasRealizadas()
        {
            Conexion repo = new Conexion();
            string consulta = "select C.DesLegajo, C.Legajo, C.Realizado  from Cronograma C";
            return repo.Listar(consulta);
        }

        public Boolean ExisteEnCronograma(int Año, int Legajo, int Curso)
        {
            Conexion repo = new Conexion();

            string consulta = "select Cr.Legajo From Cronograma Cr where Cr.Ano = " + Año + " and Cr.Legajo = " + Legajo + " and Curso = " + Curso;


            DataTable DT = repo.BuscarUno(consulta);

            return DT.Rows.Count > 0;
        }

        public DataTable BuscarUnoCursada(int Año, int Legajo, int Curso)
        {
            Conexion repo = new Conexion();

            string consulta = "select * From Cronograma Cr where Cr.Ano = " + Año + " and Cr.Legajo = " + Legajo + " and Curso = " + Curso;


            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable CronogramaPendiente(int Año)
        {
            Conexion repo = new Conexion();

            string consulta = "select C.Horas, C.Realizado, C.Legajo, C.Curso, Cu.Descripcion from Cronograma C inner join Curso Cu on Cu.Codigo = C.Curso  where C.Ano = " + Año + " and C.Horas > C.Realizado order by C.Curso desc";



            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable CronogramaHoras(string WDesdeFecha, string WHastaFecha, int TemaDesde, int TemaHasta)
        {
            string WAnioI = "";
            string WAnioII = "";

            WAnioI = WDesdeFecha.Contains("/") ? WDesdeFecha.Substring(6, 4) : WDesdeFecha.Substring(0, 4);
            WAnioII = WHastaFecha.Contains("/") ? WHastaFecha.Substring(6, 4) : WHastaFecha.Substring(0, 4);

            Conexion repo = new Conexion();

            string consulta = "select C.Ano, C.Curso, Cu.Descripcion, C.Tema, T.Descripcion, C.Legajo, l.Descripcion, C.Horas, C.Realizado from Cronograma C inner join Curso Cu on Cu.Codigo = C.Curso LEFT OUTER JOIN Tema T ON T.Curso = C.Curso AND T.Tema = C.Tema LEFT OUTER JOIN Legajo l ON l.Codigo = C.Legajo AND l.Renglon = 1  where C.Curso >= " + TemaDesde + " and C.Curso <= " + TemaHasta + " and C.Ano BETWEEN '" + WAnioI + "' AND '" + WAnioII + "' AND C.Tema <> 0 AND C.Renglon <> 0 order by C.Legajo desc";

            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable CronogramaHoras(int Año, int TemaDesde, int TemaHasta)
        {
            Conexion repo = new Conexion();

            string consulta = "select C.Ano, C.Curso, Cu.Descripcion, C.Tema, T.Descripcion, C.Legajo, l.Descripcion, C.Horas, C.Realizado from Cronograma C inner join Curso Cu on Cu.Codigo = C.Curso LEFT OUTER JOIN Tema T ON T.Curso = C.Curso AND T.Tema = C.Tema LEFT OUTER JOIN Legajo l ON l.Codigo = C.Legajo AND l.Renglon = 1  where C.Curso >= " + TemaDesde + " and C.Curso <= " + TemaHasta + " and C.Ano = " + Año + " AND C.Tema <> 0 AND C.Renglon <> 0 order by C.Legajo desc";

            DataTable DT = repo.BuscarUno(consulta);

            return DT;
        }

        public DataTable CronogramaSectorTema(int Año, int SectorDesde, int SectorHasta)
        {
            Conexion repo = new Conexion();

            string consulta = "Select L.Sector, UPPER(ISNULL(s.Descripcion, '')) , C.Curso, UPPER(Cu.Descripcion), C.Legajo, UPPER(L.Descripcion), C.Horas from Cronograma C INNER JOIN Legajo L ON L.Codigo = C.Legajo AND L.Renglon = 1 inner join Curso Cu on Cu.Codigo = C.Curso LEFT OUTER JOIN Sector s ON s.Codigo = l.Sector where L.Sector >= " + SectorDesde + " and L.Sector <= " + SectorHasta + " and Ano = " + Año + " order by C.Sector, C.Curso, Legajo";




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
