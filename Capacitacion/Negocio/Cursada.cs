using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassConexion;

namespace Negocio
{
    public class Cursada : IRepoMetodos<Cursada>
    {



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
            throw new NotImplementedException();
        }

        public Cursada BuscarUno(string IdAModificar)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable BuscarUnoGrilla(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "select cur.Curso as Tema, DesCurso = ISNULL(c.Descripcion, ''), cur.Horas, " +
            " CASE WHEN cur.TipoII = 0 THEN 'Progra' ELSE 'No Progr' END as " +
            " TipoII,  SUBSTRING(cur.ordFecha,0,5) as Ano,DesTema = ISNULL(t.Descripcion, '') " +
            " from cursadas cur LEFT OUTER JOIN Curso c ON c.Codigo = cur.Curso LEFT OUTER JOIN Tema t ON t.Tema = cur.Tema AND t.Curso = c.Codigo where cur.legajo = " + IdAModificar +
            " order by cur.Curso asc";


            return repo.Listar(consulta);
        }

        public void Modificar(Cursada t)
        {
            throw new NotImplementedException();
        }

        public void ModificarCursadaConsol(int Valor, string Clave)
        {
            Conexion  repo = new Conexion();

            string consulta = "update Cursadas set TipoCursada = " + Valor + " where Clave = '" + Clave +"'";
               
            repo.Modificar(consulta);
        }

        public void Eliminar(string IdAEliminar)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable BuscarPorLegajo(int Legajo)
        {
            Conexion Repo = new Conexion();
            string consulta = "select Curso, DesCurso, Horas, TipoII, Ano, DesTema " +
            "from cursadas where Legajo = "+ Legajo +"  order by ordfecha desc";

            System.Data.DataTable DT = Repo.Listar(consulta);
            return DT;
        }

        public System.Data.DataTable ListarCursadaCons2(int Desde, int Hasta)
        {


            Conexion repo = new Conexion();
            string consulta = "SELECT  C.curso, C.Legajo, C.Clave, C.Ano FROM Cursadas C where C.Ano>= " + Desde + " and C.Ano <= " + Hasta + " order by Clave";
            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarCursadaCons(int Desde, int Hasta)
        {


            Conexion repo = new Conexion();
            string consulta = "SELECT  C.curso, C.Legajo, C.Horas, C.Fecha, C.Clave, C.Tema, C.Ano FROM Cursadas C where C.Ano>= " + Desde + " and C.Ano <= " + Hasta + " order by Clave";
            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarInformeCons(string DesdeFecha, string HastaFecha, int DesdeTipo, int HastaTipo)
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT C.Codigo, C.Curso, C.Fecha, C.OrdFecha, C.Horas, C.Legajo, C.DesLegajo, C.Observaciones, C.TipoCursada, C.Tema, C.DesTema, Cur.Descripcion from Cursadas C, Curso Cur where C.Curso = Cur.Codigo and C.OrdFecha >= '" 
                + DesdeFecha + "' and C.OrdFecha <= '" + HastaFecha + "' and C.Legajo >= 0 and C.Legajo <= 999999 and C.TipoCursada >= " + 
                DesdeTipo + " and C.TipoCursada <= " + HastaTipo;

            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarPorLegajo(int LegajoDesd, int legajoHast)
        {


            Conexion repo = new Conexion();
            string consulta = "select Cu.Legajo, Cu.DesLegajo, Cu.Curso, Cu.DesCurso, Cu.Tema, Cu.DesTema, Cu.Horas, Cu.Codigo, Cu.Fecha, cu.Observaciones ,  CASE WHEN Cu.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada, cu.OrdFecha  from Cursadas Cu where Cu.Legajo >= " + LegajoDesd + " and Cu.Legajo <= " + legajoHast;

            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarCursoporTema(int TemaDesd, int TemajoHast, int FechaDesde, int FechaHasta)
        {


            Conexion repo = new Conexion();
            string consulta = "select C.Curso, Cu.Descripcion, C.Tema, T.Descripcion, C.Legajo, l.Descripcion, C.Horas, C.Codigo, C.Fecha, C.Observaciones,  CASE WHEN C.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada from Cursadas C LEFT OUTER JOIN Legajo l ON l.Codigo = C.Legajo AND l.Renglon = 1 LEFT OUTER JOIN Tema Cu ON Cu.Curso = c.Curso AND Cu.Tema = C.Tema LEFT OUTER JOIN Curso T ON T.Codigo = C.Curso where C.Curso >= " + TemaDesd + " and C.Curso <= " + TemajoHast + " and C.OrdFecha > = " + FechaDesde + " and C.OrdFecha < = " + FechaHasta;


            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarCursoNoRealizadosporTema(int TemaDesd, int TemajoHast, int FechaDesde, int FechaHasta, bool WExcluir99)
        {


            Conexion repo = new Conexion();
            //string consulta = "select Cr.Curso, Cu.Descripcion, Cr.Tema, T.Descripcion, Cr.Legajo, l.Descripcion, Cr.Horas, Codigo = 0, Fecha = '  /  /    ', Cr.Observaciones,  Planificada = '' from Cronograma Cr LEFT JOIN Cursadas C ON C.Legajo = Cr.Legajo AND C.Curso = Cr.Curso AND C.Tema = Cr.Tema LEFT JOIN Legajo l ON l.Codigo = Cr.Legajo AND l.Renglon = 1 LEFT OUTER JOIN Tema Cu ON Cu.Curso = cr.Curso AND Cu.Tema = Cr.Tema LEFT OUTER JOIN Curso T ON T.Codigo = Cr.Curso where (C.Curso IS NULL OR C.Tema IS NULL) And  Cr.Curso >= " + TemaDesd + " and Cr.Curso <= " + TemajoHast + " and C.OrdFecha > = " + FechaDesde + " and C.OrdFecha < = " + FechaHasta;
            string consulta = "select distinct Cr.Curso, Cu.Descripcion, Cr.Tema, T.Descripcion, Cr.Legajo, l.Descripcion, Cr.Horas, Codigo = 0, Fecha = '  /  /    ', Cr.Observaciones,  Planificada = '' from Cronograma Cr LEFT JOIN Legajo l ON l.Codigo = Cr.Legajo AND l.Renglon = 1 LEFT OUTER JOIN Tema Cu ON Cu.Curso = cr.Curso AND Cu.Tema = Cr.Tema LEFT OUTER JOIN Curso T ON T.Codigo = Cr.Curso  LEFT JOIN Cursadas C ON C.Legajo = Cr.Legajo AND C.Curso = Cr.Curso And c.Tema = cr.Tema And C.OrdFecha >= '" + FechaDesde + "' and C.OrdFecha <= '" + FechaHasta + "'  where (c.Curso IS NULL Or c.Tema IS NULL or c.Legajo IS NULL) And Cr.Curso >= '" + TemaDesd + "' and Cr.Curso <= '" + TemajoHast + "' and cr.tema > 0 And cr.Ano BETWEEN '" + FechaDesde.ToString().Substring(0, 4) + "' And '" + FechaHasta.ToString().Substring(0, 4) + "' order by cr.legajo , cr.curso, cr.tema";
            
            if (WExcluir99) consulta = "select distinct Cr.Curso, Cu.Descripcion, Cr.Tema, T.Descripcion, Cr.Legajo, l.Descripcion, Cr.Horas, Codigo = 0, Fecha = '  /  /    ', Cr.Observaciones,  Planificada = '' from Cronograma Cr LEFT JOIN Legajo l ON l.Codigo = Cr.Legajo AND l.Renglon = 1 LEFT OUTER JOIN Tema Cu ON Cu.Curso = cr.Curso AND Cu.Tema = Cr.Tema LEFT OUTER JOIN Curso T ON T.Codigo = Cr.Curso  LEFT JOIN Cursadas C ON C.Legajo = Cr.Legajo AND C.Curso = Cr.Curso And c.Tema = cr.Tema And C.OrdFecha >= '" + FechaDesde + "' and C.OrdFecha <= '" + FechaHasta + "'  where (c.Curso IS NULL Or c.Tema IS NULL or c.Legajo IS NULL) And Cr.Curso >= '" + TemaDesd + "' and Cr.Curso <= '" + TemajoHast + "' and cr.tema > 0 And cr.Ano BETWEEN '" + FechaDesde.ToString().Substring(0, 4) + "' And '" + FechaHasta.ToString().Substring(0, 4) + "' and cr.tema <> 99 order by cr.legajo , cr.curso, cr.tema";

            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarCursoporSector(int SectorDesd, int SectorHast, int FechaDesde, int FechaHasta)
        {
            Conexion repo = new Conexion();
            string consulta = "select C.Sector, S.Descripcion, C.Legajo, C.DesLegajo, C.Curso, C.DesCurso, C.Tema, C.DesTema, C.Horas, C.Codigo, C.Fecha, C.Observaciones,  CASE WHEN C.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada  from Cursadas C inner join Sector S on S.Codigo = C.Sector where C.Sector >= " + SectorDesd + " and C.Sector <= " + SectorHast + " and OrdFecha > = " + FechaDesde + " and OrdFecha < = " + FechaHasta + "Order by Curso desc";


            return repo.Listar(consulta);
        }


        public DataTable ListarCursoporSector(int SectorDesd, int SectorHast, int FechaDesde, int FechaHasta, string WTipoCursada)
        {
            Conexion repo = new Conexion();

            if (WTipoCursada.Trim() != "") WTipoCursada = " AND TipoCursada = '" + WTipoCursada + "'";

            string consulta = "select C.Sector, S.Descripcion, C.Legajo, C.DesLegajo, C.Curso, C.DesCurso, C.Tema, C.DesTema, C.Horas, C.Codigo, C.Fecha, C.Observaciones,  CASE WHEN C.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada  from Cursadas C inner join Sector S on S.Codigo = C.Sector where C.Sector >= " + SectorDesd + " and C.Sector <= " + SectorHast + " and OrdFecha > = " + FechaDesde + " and OrdFecha < = " + FechaHasta + "" + WTipoCursada + " Order by Curso desc";

            return repo.Listar(consulta);
        }
    }
}
