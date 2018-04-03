using System;
using System.Collections.Generic;
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
            string consulta = "select Curso as Tema, DesCurso, Horas, " + 
            " CASE WHEN TipoII = 0 THEN 'Progra' ELSE 'No Progr' END as " +
            " TipoII,  SUBSTRING(ordFecha,0,5) as Ano,DesTema " +
            " from cursadas where legajo = " + IdAModificar +
            " order by Curso asc";


            return repo.Listar(consulta);
        }

        public void Modificar(Cursada t)
        {
            throw new NotImplementedException();
        }

        public void ModificarCursadaConsol(int Valor, string Clave)
        {
            Conexion repo = new Conexion();

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
            string consulta = "select C.Curso, C.DesCurso, C.Tema, C.DesTema, C.Legajo, C.DesLegajo, C.Horas, C.Codigo, C.Fecha, C.Observaciones,  CASE WHEN C.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada from Cursadas C where Curso >= " + TemaDesd + " and Curso <= " + TemajoHast + " and OrdFecha > = " + FechaDesde +" and OrdFecha < = " + FechaHasta;


            return repo.Listar(consulta);
        }

        public System.Data.DataTable ListarCursoporSector(int SectorDesd, int SectorHast, int FechaDesde, int FechaHasta)
        {


            Conexion repo = new Conexion();
            string consulta = "select C.Sector, S.Descripcion, C.Legajo, C.DesLegajo, C.Curso, C.DesCurso, C.Tema, C.DesTema, C.Horas, C.Codigo, C.Fecha, C.Observaciones,  CASE WHEN C.TipoCursada = 0 THEN 'Si' ELSE 'No' END as Planificada  from Cursadas C inner join Sector S on S.Codigo = C.Sector where C.Sector >= " + SectorDesd + " and C.Sector <= " + SectorHast + " and OrdFecha > = " + FechaDesde + " and OrdFecha < = " + FechaHasta + "Order by Curso desc";


            return repo.Listar(consulta);
        }


    }
}
