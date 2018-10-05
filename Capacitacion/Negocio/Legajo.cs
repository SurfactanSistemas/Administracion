using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClassConexion;

namespace Negocio
{
    public class Legajo : IRepoMetodos<Legajo>
    {
        public int Codigo { set; get; }

        public string Descripcion { set; get; }

        public string DNI { set; get; }

        public string CUIL { set; get; }

        public string FIngreso { set; get; }

        public string EstadoI { set; get; }


        public string EstadoII { set; get; }

        public string EstadoIII { set; get; }

        public string EstadoX { set; get; }

        public string EstadoIV { set; get; }


        public string EstadoV { set; get; }


        public string EstadoVI { set; get; }

        public string EstadoVII { set; get; }


        public string EstadoVIII { set; get; }


        public string EstadoIX { set; get; }

        public string FechaVersion { set; get; }


        public string Version { set; get; }


        public Perfil Perfil;

        //public int Perfil;
        //public string ImprePerfil;
        public string FEgreso;
        public string PerfilVersion;
        public Sector Sector;
        //public string DesSector;
        public string EstaI;
        public string EstaII;
        public string EstaIII;
        public string EstaIV;
        public string EstaV;
        public string EstaVI;
        public string EstaVII;
        public string EstaVIII;
        public string EstaIX;
        public string EstaX;
        public string Actualizado;
        public string ObservExtI;
        public string ObservExtII;
        public string ObservExtIII;
        public string ObservExtIV;
        public string ObservExtV;

        public List<Tema> Temas { get; set; }

        public DataTable ListarLegajosDiscriminado(string WNombrePersonal)
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT Legajo.Codigo, Legajo.Descripcion, Legajo.FechaVersion as Vigencia, Legajo.Perfil, Perfil.Sector, Grisar = CASE Legajo.FEgreso WHEN '  /  /    ' THEN 'N' WHEN '00/00/0000' THEN 'N' WHEN NULL THEN 'N' ELSE 'S' END FROM Legajo, Tarea as Perfil WHERE Legajo.Perfil = Perfil.Codigo AND Perfil.Renglon = 1 AND Legajo.Renglon = 1 AND Legajo.Descripcion = '" + WNombrePersonal.Trim() + "' ORDER BY Legajo.Descripcion, Legajo.Codigo, Legajo.VigenciaOrd";
            DataTable Dt = repo.Listar(consulta);
            return Dt;
        }

        public DataTable ListarTodosParaGrilla()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT Clave, Codigo, Descripcion, FechaVersion, Perfil, Sector, Dni, FEgreso, Actualizado, VigenciaOrd FROM Legajo WHERE Renglon = 1 ORDER BY Descripcion, Codigo, VigenciaOrd";
            DataTable Dt = repo.Listar(consulta);
            return Dt;
        }

        public DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Legajo where Renglon = 1 order by Descripcion, Codigo, VigenciaOrd";
            DataTable Dt = repo.Listar(consulta);
            return Dt;
        }

        public int ObtenerUltimoId()
        {
            Conexion repo = new Conexion();
            string consulta = "select MAX(Codigo) + 1 from Legajo";
            int valor = int.Parse(repo.TraerUltimoId(consulta));
            return valor;
        }


        public int CantidadLegajo(int WCodigo, int WVersion)
        {
            Conexion repo = new Conexion();
            string consulta = "select COUNT (Renglon) from legajo where Codigo = " + WCodigo +" and version = " + WVersion;
            int valor = int.Parse(repo.TraerUltimoId(consulta));
            return valor;
        }

        public void Agregar()
        {
            Conexion Repo = new Conexion();

            int renglon = 1;

            foreach (var t in Temas)
            {
                var clave1 = Codigo.ToString().PadLeft(6, '0');
                var clave2 = renglon.ToString().PadLeft(2, '0');

                var claper1 = Perfil.Codigo.ToString().PadLeft(6, '0');
                var claper2 = "1".PadLeft(2, '0');

                string nece = t.Necesaria == 1 ? "X" : "";
                string dese = t.Deseable == 1 ? "X" : "";

                //int estado = ObtenerEstado(t.Estado);


                string consulta = "insert into Legajo "
                + " (Clave, Codigo,Renglon, Descripcion,FIngreso,EstadoI,"
                + " EstadoII,EstadoIII,EstadoIV,EstadoV,EstadoVI,EstadoVII,"
                + " EstadoVIII,EstadoIX,EstadoX, Curso, EstadoCurso, EstaI,"
                + " EstaII,EstaIII,EstaIV,EstaV,EstaVI,EstaVII,EstaVIII,EstaIX,EstaX,"
                + " EstaCurso,Perfil,ClavePerfil, NecesariaCurso,DeseableCurso,FechaVersion,"
                + " Version,ImprePerfil, Fegreso, PerfilVersion, Sector, DesSector, ObservaI1,"
                + " ObservaI2, ObservaI3, ObservaI4, ObservaI5, ObservaII1, ObservaII2, ObservaII3,"
                + " ObservaII4, ObservaII5, dni)"
                + " values " +
                "('" + clave1 + clave2 + "'," + Codigo + "," + renglon + ",'" + Descripcion + "','" + FIngreso + "','" + EstadoI + "',"
                + " '" + EstadoII + "','" + EstadoIII + "','" + EstadoIV + "','" + EstadoV + "','" + EstadoVI + "','" + EstadoVII + "',"
                + " '" + EstadoVIII + "','" + EstadoIX + "','" + EstadoX + "'," + t.Codigo + ",'" + t.Observacion + "', '" + EstaI + "',"
                + " '" + EstaII + "','" + EstaIII + "','" + EstaIV + "','" + EstaV + "','"
                + EstaVI + "','" + EstaVII + "','" + EstaVIII + "','" + EstaIX + "','" + EstaX + "',"
                + " " +t.Estado + "," + Perfil.Codigo + ",'" + claper1 + claper2 + "','" + nece + "','" + dese + "','" + FechaVersion + "',"
                + " " + Version + " ,'" + Perfil.Descripcion + "','" + FEgreso + "'," + Perfil.Version + "," + Sector.Codigo + ",'" + Sector.Descripcion + "',"
                + "' ',' ', ' ', ' ', ' ', '" + ObservExtI + "','" + ObservExtII + "','" + ObservExtIII + "','" + ObservExtIV + "','" + ObservExtV + "', '"
                + DNI +"')";

                Repo.Agregar(consulta);

                renglon++;
            }
            
        }

        public Legajo BuscarUno(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "select *, Perfil.Sector as WSector from legajo as L, Tarea as Perfil where L.Perfil = Perfil.Codigo AND Perfil.Renglon = 1 AND L.codigo = " + IdAModificar + "order by L.Renglon";
            DataTable DT = repo.BuscarUno(consulta);

            Legajo obj = new Legajo();

            if (DT.Rows.Count > 0)
            {
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                obj.DNI = DT.Rows[0]["dni"].ToString();
                //obj.CUIL = DT.Rows[0]["CUIL"].ToString();
                //obj.Curso = int.Parse(DT.Rows[0])
                obj.FechaVersion = DT.Rows[0]["FechaVersion"].ToString();
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.Version = DT.Rows[0]["Version"].ToString();
                obj.FIngreso = DT.Rows[0]["FIngreso"].ToString();
                obj.FEgreso = DT.Rows[0]["Fegreso"].ToString();
                obj.EstadoI = DT.Rows[0]["EstadoI"].ToString();
                obj.EstadoII = DT.Rows[0]["EstadoII"].ToString();
                obj.EstadoIII = DT.Rows[0]["EstadoIII"].ToString();
                obj.EstadoIV = DT.Rows[0]["EstadoIV"].ToString();
                obj.EstadoV = DT.Rows[0]["EstadoV"].ToString();
                obj.EstadoVI = DT.Rows[0]["EstadoVI"].ToString();
                obj.EstadoVII = DT.Rows[0]["EstadoVII"].ToString();
                obj.EstadoVIII = DT.Rows[0]["EstadoVIII"].ToString();
                obj.EstadoIX = DT.Rows[0]["EstadoIX"].ToString();
                obj.EstadoX = DT.Rows[0]["EstadoX"].ToString();
                obj.EstaI = DT.Rows[0]["EstaI"].ToString();
                obj.EstaII = DT.Rows[0]["EstaII"].ToString();
                obj.EstaIII = DT.Rows[0]["EstaIII"].ToString();
                obj.EstaIV = DT.Rows[0]["EstaIV"].ToString();
                obj.EstaV = DT.Rows[0]["EstaV"].ToString();
                obj.EstaVI = DT.Rows[0]["EstaVI"].ToString();
                obj.EstaVII = DT.Rows[0]["EstaVII"].ToString();
                obj.EstaVIII = DT.Rows[0]["EstaVIII"].ToString();
                obj.EstaIX = DT.Rows[0]["EstaIX"].ToString();
                obj.EstaX = DT.Rows[0]["EstaX"].ToString();
                obj.Actualizado = DT.Rows[0]["Actualizado"].ToString();
                obj.ObservExtI = DT.Rows[0]["ObservaII1"].ToString();
                obj.ObservExtII = DT.Rows[0]["ObservaII2"].ToString();
                obj.ObservExtIII = DT.Rows[0]["ObservaII3"].ToString();
                obj.ObservExtIV = DT.Rows[0]["ObservaII4"].ToString();
                obj.ObservExtV = DT.Rows[0]["ObservaII5"].ToString();
                obj.Perfil = new Perfil
                {
                    Codigo = int.Parse((DT.Rows[0]["Perfil"].ToString())),
                    Descripcion = DT.Rows[0]["ImprePerfil"].ToString()
                };
                //obj.ImprePerfil = DT.Rows[0]["ImprePerfil"].ToString();
                //obj.PerfilVersion = DT.Rows[0]["PerfilVersion"].ToString();

                int perver = 0;
                int.TryParse(DT.Rows[0]["PerfilVersion"].ToString(), out perver);
                obj.Perfil.Version = perver;

                Sector S = new Sector {Codigo = int.Parse(DT.Rows[0]["WSector"].ToString())};
                S = S.BuscarUno(S.Codigo.ToString());
                obj.Sector = new Sector();
                obj.Sector = S;

                obj.Temas = new List<Tema>();
                //FALTA TEMAS
                foreach (DataRow item in DT.Rows)
                {
                    Tema T = new Tema {Codigo = int.Parse(item["Curso"].ToString())};
                    //T = T.BuscarUno(T.Codigo.ToString(), renglon);
                    T = T.BuscarUno_Tema(T.Codigo.ToString());
                    //T.Descripcion = T.
                    T.Necesaria = item["NecesariaCurso"].ToString() == "X" ? 1 : 0;
                    T.Deseable = item["DeseableCurso"].ToString() == "X" ? 1 : 0;
                    T.EstadoCurso = item["EstadoCurso"].ToString();
                    T.EstaCurso = int.Parse(item["EstaCurso"].ToString());
                    obj.Temas.Add(T);
                }

                //double hora_parse = 0;
                //double.TryParse(DT.Rows[0]["Horas"].ToString(), out hora_parse);
                //if (hora_parse == 0) obj.Horas = null;
                //else { obj.Horas = hora_parse; }

            }
            return obj;
        }

        public void ActualizarFechasIngresoOrden()
        {
            DataTable WLegajos = new DataTable();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Surfactan"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT DISTINCT Codigo, FechaVersion FROM Legajo WHERE Renglon = 1 ORDER BY Codigo";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            WLegajos.Load(dr);
                        }
                    }

                    string[] WFechaOrd = new string[3];

                    foreach (DataRow row in WLegajos.Rows)
                    {
                        WFechaOrd = row["FechaVersion"].ToString().Split('/');
                        Array.Reverse(WFechaOrd);
                        string aux = string.Join("", WFechaOrd);

                        cmd.CommandText = "UPDATE Legajo SET VigenciaOrd = '" + aux + "' WHERE Codigo = '" + row["Codigo"] + "'";
                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }

        public void ActualizarPerfil(int WPerfil, int WVersion)
        {
            Conexion repo = new Conexion();
            string consulta = "update Legajo set Actualizado = 'N' where Perfil = " + WPerfil + " and PerfilVersion = " + WVersion;
            repo.Modificar(consulta);
        
        }

        public void ModificarN(Legajo L)
        {
            Conexion repo = new Conexion();

            

            
                string consulta = "update Legajo set "
                + " Descripcion = '" + L.Descripcion + "', FIngreso = '" + L.FIngreso + "', Perfil = '" + L.Perfil.Codigo + "',"
                + " EstadoI = '" + L.EstadoI + "', EstadoII = '" + L.EstadoII + "', EstadoIII = '" + L.EstadoIII + "',"
                + " EstadoIV = '" + L.EstadoIV + "', EstadoV = '" + L.EstadoV + "', EstadoVI = '" + L.EstadoVI + "',"
                + " EstadoVII = '" + L.EstadoVII + "', EstadoVIII = '" + L.EstadoVIII + "', EstadoIX = '" + L.EstadoIX + "',"
                + " EstadoX = '" + L.EstadoX + "', EstaI = '" + L.EstaI + "', EstaII = '" + L.EstaII + "',"
                + " EstaIII = '" + L.EstaIII + "', EstaIV = '" + L.EstaIV + "', EstaV = '" + L.EstaV + "',"
                + " EstaVI = '" + L.EstaVI + "', EstaVII = '" + L.EstaVII + "', EstaVIII = '" + L.EstaVIII + "',"
                + " EstaIX = '" + L.EstaIX + "', EstaX = '" + L.EstaX + "',"
                + " ObservaI1 = '" + L.EstadoI + "', ObservaI2 = '" + L.EstadoII + "', ObservaI3 = '" + L.EstadoIII + "',"
                + " ObservaI4 = '" + L.EstadoIV + "', ObservaI5 = '" + L.EstadoV + "', ObservaII1 = '" + L.ObservExtI + "',"
                + " ObservaII2 = '" + L.ObservExtII + "', ObservaII3 = '" + L.ObservExtIII + "', ObservaII4 = '" + L.ObservExtIV + "',"
                + " ObservaII5 = '" + L.ObservExtIV + "', Actualizado = ' ', Sector = '" + L.Sector.Codigo + "', DesSector = '" + L.Sector.Descripcion + "', Dni = '" + L.DNI + "'  where Codigo = " + L.Codigo;

                repo.Modificar(consulta);

                
            }
            


        

        public void Eliminar(string IdAEliminar)
        {
            Conexion repo = new Conexion();
            repo.Eliminar("delete Legajo where codigo = " + IdAEliminar);


        }


        public DataTable BuscarCursosPlanificacion(string p)
        {
            Conexion repo = new Conexion();
            string consulta = "select L.Curso as Tema, C.Descripcion as DesTema,  L.Tema as Curso, " +
                "'' as DesCurso, C.Horas, 0.0 as Realizado  from legajo L " +
            " inner join Curso C on C.Codigo = L.Curso  where L.codigo = " + p + " and L.EstaCurso <> 1 and L.EstaCurso <> 2 and L.EstaCurso<>6 ";

            DataTable DT = repo.BuscarUno(consulta);
            return DT;
        }


        public DataTable BuscarCursos(string p)
        {
            Conexion repo = new Conexion();
            string consulta = "select L.Curso as Tema, C.Descripcion as DesTema,  L.Tema as Curso, " +
                "'' as DesCurso, C.Horas, 0.0 as Realizado  from legajo L " +
            " inner join Curso C on C.Codigo = L.Curso  where L.codigo = " + p;

            DataTable DT = repo.BuscarUno(consulta);
            return DT;
        }

        public DataTable ListarLegajosdeCompetencias(int Desd, int Hast)
        {
            Conexion repo = new Conexion();
            string consulta = "select distinct  L.Codigo, L.Descripcion, L.Perfil ,L.ImprePerfil,L.Sector, L.DesSector, L.Version, L.Fegreso,L.FIngreso, " +
                "T.TareasI, T.TareasII, T.TareasIII, T.DescriI,T.DescriII,t.DescriIII, T.DescriIV, T.DescriV,T.Fisica,T.OtrosI,T.OtrosII, " +
                "T.Equivalencias,T.EquivalenciasII, T.ObservaI, T.ObservaII, T.ObservaIII, T.ObservaIV, T.ObservaV, "+
                "T.NecesariaI, T.NecesariaII,T.NecesariaIII, T.NecesariaIV,T.NecesariaV, T.NecesariaVI,T.NecesariaVII, T.NecesariaVIII, "+
                "T.DeseableI, T.DeseableII,T.DeseableIII, T.DeseableIV,T.DeseableV, T.DeseableVI,T.DeseableVII, T.DeseableVIII,L.renglon, "+
                "L.EstadoI, " +
                "L.EstadoII,L.EstadoIII,L.EstadoIV,L.EstadoV,L.EstadoVI,L.EstadoVII, "+
                "L.EstadoVIII,L.EstadoIX,L.EstadoX,  L.EstaI, "+
                "L.EstaII,L.EstaIII,L.EstaIV,L.EstaV,L.EstaVI,L.EstaVII,L.EstaVIII,L.EstaIX,L.EstaX, "+
                "L.Curso, C.Descripcion as DescCurso,  L.NecesariaCurso,L.DeseableCurso,L.EstaCurso,L.EstadoCurso "+
                "from legajo L"+ 
                "inner join tarea T on T.Codigo = L.Perfil inner join Curso C on L.Curso = C.Codigo "+
                "where L.codigo between " + Desd + " and " + Hast +" order by L.codigo, L.Curso";
            DataTable Dt = repo.Listar(consulta);
            return Dt;
        }

        public DataTable LegajoporPerfil(int PerfilDesde, int PerfilHasta)
        {
            Conexion repo = new Conexion();
            string consulta = "select L.Perfil, L.ImprePerfil, L.Codigo, L.Descripcion, L.Version, L.FechaVersion from Legajo L where L.Perfil >= " + PerfilDesde + " and L.Perfil <= " + PerfilHasta + " order by L.Perfil, L.Codigo desc ";

            DataTable DT = repo.BuscarUno(consulta);
            return DT;
        }

        public DataTable LegajoConNecesidades(int DesdeTema, int HastaTema)
        {
            Conexion repo = new Conexion();
            //string consulta = "select L.Curso, C.Descripcion, L.Codigo, L.Descripcion, CASE WHEN L.EstaCurso = 3 THEN 'Reforzar'  WHEN L.EstaCurso = 4 THEN 'En Entrenamiento' WHEN L.EstaCurso = 5 THEN 'No Cumple' WHEN L.EstaCurso = 8 THEN 'Cumple Actualmente' END as Estado from Legajo L inner join Curso C on C.Codigo = L.Curso where Curso >= " + DesdeTema + " and Curso <= "+HastaTema + " and EstaCurso <> 0 and EstaCurso<> 1  and EstaCurso <> 2  and EstaCurso <> 6 and EstaCurso <> 7 order by Codigo desc  ";
            string consulta = "select L.Curso, C.Descripcion, L.Codigo, L.Descripcion, CASE WHEN L.EstaCurso = 3 THEN 'Reforzar'  WHEN L.EstaCurso = 4 THEN 'En Entrenamiento' WHEN L.EstaCurso = 5 THEN 'No Cumple' WHEN L.EstaCurso = 8 THEN 'Cumple Actualmente' END as Estado from Legajo L inner join Curso C on C.Codigo = L.Curso where Curso >= " + DesdeTema + " and Curso <= " + HastaTema + " and EstaCurso IN (3,4,5,8) AND (L.FEgreso = '  /  /    '  OR L.FEgreso = '00/00/0000' OR L.FEgreso = '') order by L.Codigo desc";

            DataTable DT = repo.BuscarUno(consulta);
            return DT;
        }



        public System.Data.DataTable LegajoPerfilResponsable(int Legajo)
        {
            Conexion repo = new Conexion();
            string consulta = "select distinct L.Perfil, T.Responsable, T.ResponsableII, L.Descripcion from Legajo L inner join Tarea T on T.Codigo = L.Perfil where L.Codigo = " + Legajo;


            System.Data.DataTable DT = repo.BuscarUno(consulta);
            return DT;
        }

        public void Modificar(Legajo t)
        {
            throw new NotImplementedException();
        }
    }
}
