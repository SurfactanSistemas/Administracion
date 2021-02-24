using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClassConexion;

namespace Negocio
{
    public class Perfil : IRepoMetodos<Perfil>
    {
        public int Codigo;
        public string Descripcion;
        public string Vigencia;
        public int Version;

        public Sector sector;
        public Responsable R;
        public Responsable R2;

        public string TareasI;
        public string TareasII;
        public string TareasIII;

        public string DescriI;
        public string ObservaI;
        public int NecesariaI;
        public int DeseableI;
        public string DescriII;
        public string ObservaII;
        public int NecesariaII;
        public int DeseableII;
        public string DescriIII;
        public string ObservaIII;
        public int NecesariaIII;
        public int DeseableIII;
        public string DescriIV;
        public string ObservaIV;
        public int NecesariaIV;
        public int DeseableIV;
        public string DescriV;
        public string ObservaV;
        public int NecesariaV;
        public int DeseableV;

        public string Fisica;
        public int NecesariaVI;
        public int DeseableVI;
        public string OtrosI;
        public int NecesariaVII;
        public int DeseableVII;
        public string OtrosII;
        public int NecesariaVIII;
        public int DeseableVIII;
        public string EquivalenciasI;
        public string EquivalenciasII;

        public List<Tema> Temas { get; set; }

        public DataTable ListarTodos()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT T.Codigo,T.Descripcion,T.Vigencia,T.Version,T.Sector" +
            ",S.Descripcion, T.Responsable, T.ResponsableII, T.TareasI, T.TareasII, T.TareasIII," +
            "DescriI, ObservaI,  NecesariaI, DeseableI," +
            "DescriII, ObservaII,  NecesariaII, DeseableII," +
            "DescriIII, ObservaIII,  NecesariaIII, DeseableIII," +
            "DescriIV, ObservaIV,  NecesariaIV, DeseableIV," +
            "DescriV, ObservaV,  NecesariaV, DeseableV," +
            "Fisica, NecesariaVI, DeseableVI," +
            "OtrosI, NecesariaVII, DeseableVII," +
            "OtrosII, NecesariaVIII, DeseableVIII," +
             "Equivalencias,EquivalenciasII " +
            "FROM Tarea T inner join Sector S on S.Codigo = T.Sector" +
             " where T.Renglon = 1   order by T.Codigo asc";
            return repo.Listar(consulta);
        }

        public int ObtenerUltimoId()
        {
            Conexion repo = new Conexion();
            string consulta = "select (max(codigo) +1) from tarea Where Codigo < 1000";
            string valor = repo.TraerUltimoId(consulta);
            return int.Parse(valor);
            
        }

        public void ModificarN(DataTable dtTemas, DataTable dtTemasEliminado)
        {
            Conexion repo = new Conexion();
            int renglon = 1;

            foreach (DataRow fila in dtTemas.Rows)
            {
                if (fila[4].ToString() == "0")
                {
                    string consulta = "update Tarea set "
                + " Descripcion = '" + Descripcion + "', Vigencia = '" + Vigencia + "', Sector = '" + sector.Codigo + "',"
                + " TareasI = '" + TareasI + "', TareasII = '" + TareasII + "', TareasIII = '" + TareasIII + "',"
                + " DescriI = '" + DescriI + "', DescriII = '" + DescriII + "', DescriIII = '" + DescriIII + "',"
                + " DescriIV = '" + DescriIV + "', DescriV = '" + DescriV + "', ObservaI = '" + ObservaI + "',"
                + " ObservaII = '" + ObservaII + "', ObservaIII = '" + ObservaIII + "', ObservaIV = '" + ObservaIV + "',"
                + " ObservaV = '" + ObservaV + "', NecesariaI = " + NecesariaI + ", NecesariaII = " + NecesariaII + ","
                + " NecesariaIII = " + NecesariaIII + ", NecesariaIV = " + NecesariaIV + ", NecesariaV = " + NecesariaV + ","
                + " DeseableI = " + DeseableI + ", DeseableII = " + DeseableII + ", DeseableIII = " + DeseableIII + ", "
                + " DeseableIV = " + DeseableIV + ", DeseableV = " + DeseableV + ","
                + " Equivalencias = '" + EquivalenciasI + "', Fisica = '" + Fisica + "', OtrosI = '" + OtrosI + "',"
                + " OtrosII = '" + OtrosII + "', Version = " + Version + ", NecesariaVI = " + NecesariaVI + ", NecesariaVII = " + NecesariaVII + ","
                + " NecesariaVIII = " + NecesariaVIII + ", DeseableVI = " + DeseableVI + ", DeseableVII = " + DeseableVII + ", "
                + " DeseableVIII = " + DeseableVIII + ", EquivalenciasII = '" + EquivalenciasII + "', Responsable = " + R.Codigo + ","
                + " ResponsableII = " + R2.Codigo + ", Curso = " + int.Parse(fila[0].ToString()) + ", NecesariaCurso = '" + fila[2]
                + "', DeseableCurso = '" + fila[3] + "'  where Codigo = " + Codigo + " and Renglon = " + renglon;





                    repo.Modificar(consulta);
                }
                else if (fila[4].ToString() == "1")
                {
                    var clave1 = Codigo.ToString().PadLeft(6, '0');
                    var clave2 = renglon.ToString().PadLeft(2, '0');

                    string consulta = "insert into Tarea "
                    + " (Clave,Codigo,Renglon,Descripcion,Vigencia, Sector, TareasI, TareasII, TareasIII,DescriI, DescriII,DescriIII, DescriIV,"
                    + " DescriV, ObservaI, ObservaII,ObservaIII,ObservaIV,ObservaV,NecesariaI,NecesariaII,NecesariaIII,NecesariaIV,NecesariaV,"
                    + " DeseableI,DeseableII,DeseableIII,DeseableIV,DeseableV, Equivalencias, Fisica, OtrosI, OtrosII, Curso,NecesariaCurso, DeseableCurso,"
                    + " Version,NecesariaVI, NecesariaVII, NecesariaVIII, DeseableVI,DeseableVII,DeseableVIII,EquivalenciasII, Responsable, ResponsableII)"
                    + " values"
                    + "('" + clave1 + clave2 + "','" + Codigo + "','" + renglon + "','" + Descripcion + "','" + Vigencia + "','" + sector.Codigo + "','" + TareasI + "','"
                    + TareasII + "','" + TareasIII
                    + "','" + DescriI + "','" + DescriII + "','" + DescriIII + "','" + DescriIV + "','" + DescriV + "','" + ObservaI + "','" + ObservaII + "','"
                    + ObservaIII + "','" + ObservaIV + "','" + ObservaV + "','" + NecesariaI + "','" + NecesariaII + "','" + NecesariaIII + "','" + NecesariaIV
                    + "','" + NecesariaV + "','" + DeseableI + "','" + DeseableII + "','" + DeseableIII + "','" + DeseableIV + "','" + DeseableV + "','" + EquivalenciasI + "','"
                    + Fisica + "','" + OtrosI + "','" + OtrosII + "','" + int.Parse(fila[0].ToString()) + "', '" + fila[2] + "', '" + fila[3] + "','" + Version + "','" + NecesariaVI
                    + "','" + NecesariaVII + "','" + NecesariaVIII + "','" + DeseableVI + "','" + DeseableVII + "','" + DeseableVIII + "','" + EquivalenciasII + "',"
                    + R.Codigo + "','" + R2.Codigo + "')";

                    repo.Agregar(consulta);
                }

                renglon++;

                
            }

            if (dtTemasEliminado.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTemasEliminado.Rows)
                {
                    repo.Eliminar("delete tarea where codigo = " + Codigo + " and Curso = " + int.Parse(dr[0].ToString()));
                }

            }
            
        }


        public void Agregar()
        {
            Conexion repo = new Conexion();
            int renglon = 1;

            foreach (var t in Temas)
            {
                var clave1 = Codigo.ToString().PadLeft(6, '0');
                var clave2 = renglon.ToString().PadLeft(2, '0');

                string consulta = "insert into Tarea "
                + " (Clave,Codigo,Renglon,Descripcion,Vigencia, Sector, TareasI, TareasII, TareasIII,DescriI, DescriII,DescriIII, DescriIV,"
                + " DescriV, ObservaI, ObservaII,ObservaIII,ObservaIV,ObservaV,NecesariaI,NecesariaII,NecesariaIII,NecesariaIV,NecesariaV,"
                + " DeseableI,DeseableII,DeseableIII,DeseableIV,DeseableV, Equivalencias, Fisica, OtrosI, OtrosII, Curso,NecesariaCurso, DeseableCurso,"
                + " Version,NecesariaVI, NecesariaVII, NecesariaVIII, DeseableVI,DeseableVII,DeseableVIII,EquivalenciasII, Responsable, ResponsableII)"
                + " values"
                + "('" + clave1 + clave2 + "','" + Codigo + "','" + renglon + "','" + Descripcion + "','" + Vigencia + "','" + sector.Codigo + "','" + TareasI + "','"
                + TareasII + "','" + TareasIII
                + "','" + DescriI + "','" + DescriII + "','" + DescriIII + "','" + DescriIV + "','" + DescriV + "','" + ObservaI + "','" + ObservaII + "','"
                + ObservaIII + "','" + ObservaIV + "','" + ObservaV + "','" + NecesariaI + "','" + NecesariaII + "','" + NecesariaIII + "','" + NecesariaIV
                + "','" + NecesariaV + "','" + DeseableI + "','" + DeseableII + "','" + DeseableIII + "','" + DeseableIV + "','" + DeseableV + "','" + EquivalenciasI + "','"
                + Fisica + "','" + OtrosI + "','" + OtrosII + "','" + t.Codigo + "','" + t.Necesaria + "','" + t.Deseable + "','" + Version + "','" + NecesariaVI
                + "','" + NecesariaVII + "','" + NecesariaVIII + "','" + DeseableVI + "','" + DeseableVII + "','" + DeseableVIII + "','" + EquivalenciasII + "','"
                + R.Codigo + "','" + R2.Codigo + "')";
                
                repo.Agregar(consulta);

                renglon++;
            }

            
        }

        public Perfil BuscarUno(string IdAModificar)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from Tarea where Codigo = '" + IdAModificar + "' Order by Renglon";
            DataTable DT = repo.BuscarUno(consulta);
            Perfil obj = new Perfil();

            if (DT.Rows.Count > 0)
            {
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                //obj.Curso = int.Parse(DT.Rows[0])
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.Version = int.Parse(DT.Rows[0]["Version"].ToString());
                obj.Vigencia = DT.Rows[0]["Vigencia"].ToString();
                Responsable R1 = new Responsable();
                R1 = R1.BuscarUno(DT.Rows[0]["Responsable"].ToString());
                obj.R = R1;

                Responsable R2 = new Responsable();
                R2 = R2.BuscarUno(DT.Rows[0]["ResponsableII"].ToString());
                obj.R2 = R2;

                Sector S = new Sector();
                S.Codigo = int.Parse(DT.Rows[0]["Sector"].ToString());
                S = S.BuscarUno(S.Codigo.ToString());
                obj.sector = S;
                obj.TareasI = DT.Rows[0]["TareasI"].ToString();
                obj.TareasII = DT.Rows[0]["TareasII"].ToString();
                obj.TareasIII = DT.Rows[0]["TareasIII"].ToString();
                obj.DescriI = DT.Rows[0]["DescriI"].ToString();
                obj.DescriII = DT.Rows[0]["DescriII"].ToString();
                obj.DescriIII = DT.Rows[0]["DescriIII"].ToString();
                obj.DescriIV = DT.Rows[0]["DescriIV"].ToString();
                obj.DescriV = DT.Rows[0]["DescriV"].ToString();
                obj.ObservaI = DT.Rows[0]["ObservaI"].ToString();
                obj.ObservaII = DT.Rows[0]["ObservaII"].ToString();
                obj.ObservaIII = DT.Rows[0]["ObservaIII"].ToString();
                obj.ObservaIV = DT.Rows[0]["ObservaIV"].ToString();
                obj.ObservaV = DT.Rows[0]["ObservaV"].ToString();
                obj.NecesariaI = int.Parse(DT.Rows[0]["NecesariaI"].ToString());
                obj.NecesariaII = int.Parse(DT.Rows[0]["NecesariaII"].ToString());
                obj.NecesariaIII = int.Parse(DT.Rows[0]["NecesariaIII"].ToString());
                obj.NecesariaIV = int.Parse(DT.Rows[0]["NecesariaIV"].ToString());
                obj.NecesariaV = int.Parse(DT.Rows[0]["NecesariaV"].ToString());
                obj.NecesariaVI = int.Parse(DT.Rows[0]["NecesariaVI"].ToString());
                obj.NecesariaVII = int.Parse(DT.Rows[0]["NecesariaVII"].ToString());
                obj.NecesariaVIII = int.Parse(DT.Rows[0]["NecesariaVIII"].ToString());

                obj.DeseableI = int.Parse(DT.Rows[0]["DeseableI"].ToString());
                obj.DeseableII = int.Parse(DT.Rows[0]["DeseableII"].ToString());
                obj.DeseableIII = int.Parse(DT.Rows[0]["DeseableIII"].ToString());
                obj.DeseableIV = int.Parse(DT.Rows[0]["DeseableIV"].ToString());
                obj.DeseableV = int.Parse(DT.Rows[0]["DeseableV"].ToString());
                obj.DeseableVI = int.Parse(DT.Rows[0]["DeseableVI"].ToString());
                obj.DeseableVII = int.Parse(DT.Rows[0]["DeseableVII"].ToString());
                obj.DeseableVIII = int.Parse(DT.Rows[0]["DeseableVIII"].ToString());

                obj.Fisica = DT.Rows[0]["Fisica"].ToString();
                obj.OtrosI = DT.Rows[0]["OtrosI"].ToString();
                obj.OtrosII = DT.Rows[0]["OtrosII"].ToString();

                obj.EquivalenciasI = DT.Rows[0]["Equivalencias"].ToString();
                obj.EquivalenciasII = DT.Rows[0]["EquivalenciasII"].ToString();

                obj.Temas = new List<Tema>();
                //FALTA TEMAS
                int renglon = 0;
                foreach (DataRow item in DT.Rows)
                {
                    Tema T = new Tema();
                    T.Codigo = int.Parse(item["Curso"].ToString());
                    //T = T.BuscarUno(T.Codigo.ToString(), renglon);
                    T = T.BuscarUno_Tema(T.Codigo.ToString());
                    //T.Descripcion = T.
                    T.Necesaria = DT.Rows[renglon]["NecesariaCurso"].ToString().ToUpper();
                    T.Deseable = DT.Rows[renglon]["DeseableCurso"].ToString().ToUpper();
                    //T.Deseable = item["DeseableCurso"].ToString() == "1" ? 1 : 0;
                    obj.Temas.Add(T);
                    renglon++;
                }

                //double hora_parse = 0;
                //double.TryParse(DT.Rows[0]["Horas"].ToString(), out hora_parse);
                //if (hora_parse == 0) obj.Horas = null;
                //else { obj.Horas = hora_parse; }

            }
            return obj;
        }

        public void Modificar(Perfil per)
        {
            Conexion repo = new Conexion();

            IEnumerable<int> codsAAgregar = ModificarTemas(per);

            //var clave1 = t.Curso_Id.ToString().PadLeft(4, '0');
            //var clave2 = t.Tema.ToString().PadLeft(4, '0');
            //var horas = t.Horas.ToString().Replace(",", ".");

            string consulta = "update Tarea set "
                + " Descripcion = '" + per.Descripcion + "', Vigencia = '" + per.Vigencia + "', Sector = '" + per.sector.Codigo + "',"
                + " TareasI = '" + per.TareasI + "', TareasII = '" + per.TareasII + "', TareasIII = '" + per.TareasIII + "',"
                + " DescriI = '" + per.DescriI + "', DescriII = '" + per.DescriII + "', DescriIII = '" + per.DescriIII + "',"
                + " DescriIV = '" + per.DescriIV + "', DescriV = '" + per.DescriIV + "', ObservaI = '" + per.ObservaI + "',"
                + " ObservaII = '" + per.ObservaII + "', ObservaIII = '" + per.ObservaIII + "', ObservaIV = '" + per.ObservaIV + "',"
                + " ObservaV = '" + per.ObservaV + "', NecesariaI = " + per.NecesariaI + ", NecesariaII = " + per.NecesariaII + ","
                + " NecesariaIII = " + per.NecesariaIII + ", NecesariaIV = " + per.NecesariaIV + ", NecesariaV = " + per.NecesariaV + ","
                + " DeseableI = " + per.DeseableI + ", DeseableII = " + per.DeseableII + ", DeseableIII = " + per.DeseableIII + ", "
                + " DeseableIV = " + per.DeseableIV + ", DeseableV = " + per.DeseableV + ","
                + " Equivalencias = '" + per.EquivalenciasI + "', Fisica = '" + per.Fisica + "', OtrosI = '" + per.OtrosI + "',"
                + " OtrosII = '" + per.OtrosII + "', Version = " + per.Version + ", NecesariaVI = " + per.NecesariaVI + ", NecesariaVII = " + per.NecesariaVII + ","
                + " NecesariaVIII = " + per.NecesariaVIII + ", DeseableVI = " + per.DeseableVI + ", DeseableVII = " + per.DeseableVII + ", "
                + " DeseableVIII = " + per.DeseableVIII + ", EquivalenciasII = '"+per.EquivalenciasII+"', Responsable = "+per.R.Codigo+","
                + " ResponsableII = "+per.R2.Codigo+" where Codigo = "+ per.Codigo;

            GenerarTemas(per, codsAAgregar);

            //string consulta = "update tema set Descripcion = '" + t.Descripcion + "', Horas = " + horas + "where clave = '" + clave1 + clave2 + "'";
            //repo.Modificar(consulta);
        }

        private void GenerarTemas(Perfil per, IEnumerable<int>  codsAAgregar)
        {
            foreach (var item in per.Temas)
            {
                for (int i = 0; i < codsAAgregar.Count(); i++)
                {
                    if(!codsAAgregar.ElementAt(i).Equals(item.Codigo))
                    {
                        string qry = "update Tarea set "
                        + " NecesariaCurso = '" + item.Necesaria+"', DeseableCurso = '"+item.Deseable+"' " 
                        + " where Curso = " + item.Codigo + " and Codigo = " + per.Codigo;

                        //Actualizo
                    }
                }
                
            }
        }

        private IEnumerable<int> ModificarTemas(Perfil per)
        {
            int[] codigosNv = new int[per.Temas.Count];
            int[] codigosOld = new int[Temas.Count];

            for (int i = 0; i < per.Temas.Count; i++)
			{
                codigosNv[i] = per.Temas[i].Codigo;
			}

            for (int i = 0; i < Temas.Count; i++)
            {
                codigosOld[i] = Temas[i].Codigo;
            }
            //Tengo el codigo del nuevo
            return  codigosNv.Except(codigosOld);
           
            
        }

        public void Eliminar(string IdAEliminar)
        {
            Conexion repo = new Conexion();
            repo.Eliminar("delete tarea where codigo = " + IdAEliminar);
        }



        public Perfil BuscarUno(string IdAModificar, string version)
        {
            Conexion repo = new Conexion();
            string consulta = "select *, Vigencia = HastaVigencia, Responsable = 0, ResponsableII = 0 from TareaVersion where Codigo = " + IdAModificar + " and version = " + version;
            DataTable DT = repo.BuscarUno(consulta);
            Perfil obj = new Perfil();

            if (DT.Rows.Count > 0)
            {
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.Version = int.Parse(DT.Rows[0]["Version"].ToString());
                obj.Vigencia = DT.Rows[0]["Vigencia"].ToString();
                Responsable R1 = new Responsable();
                R1 = R1.BuscarUno(DT.Rows[0]["Responsable"].ToString());
                obj.R = R1;

                Responsable R2 = new Responsable();
                R2 = R2.BuscarUno(DT.Rows[0]["ResponsableII"].ToString());
                obj.R2 = R2;

                Sector S = new Sector();
                S.Codigo = int.Parse(DT.Rows[0]["Sector"].ToString());
                S = S.BuscarUno(S.Codigo.ToString());
                obj.sector = S;
                obj.TareasI = DT.Rows[0]["TareasI"].ToString();
                obj.TareasII = DT.Rows[0]["TareasII"].ToString();
                obj.TareasIII = DT.Rows[0]["TareasIII"].ToString();
                obj.DescriI = DT.Rows[0]["DescriI"].ToString();
                obj.DescriII = DT.Rows[0]["DescriII"].ToString();
                obj.DescriIII = DT.Rows[0]["DescriIII"].ToString();
                obj.DescriIV = DT.Rows[0]["DescriIV"].ToString();
                obj.DescriV = DT.Rows[0]["DescriV"].ToString();
                obj.ObservaI = DT.Rows[0]["ObservaI"].ToString();
                obj.ObservaII = DT.Rows[0]["ObservaII"].ToString();
                obj.ObservaIII = DT.Rows[0]["ObservaIII"].ToString();
                obj.ObservaIV = DT.Rows[0]["ObservaIV"].ToString();
                obj.ObservaV = DT.Rows[0]["ObservaV"].ToString();
                obj.NecesariaI = int.Parse(DT.Rows[0]["NecesariaI"].ToString());
                obj.NecesariaII = int.Parse(DT.Rows[0]["NecesariaII"].ToString());
                obj.NecesariaIII = int.Parse(DT.Rows[0]["NecesariaIII"].ToString());
                obj.NecesariaIV = int.Parse(DT.Rows[0]["NecesariaIV"].ToString());
                obj.NecesariaV = int.Parse(DT.Rows[0]["NecesariaV"].ToString());
                obj.NecesariaVI = int.Parse(DT.Rows[0]["NecesariaVI"].ToString());
                obj.NecesariaVII = int.Parse(DT.Rows[0]["NecesariaVII"].ToString());
                obj.NecesariaVIII = int.Parse(DT.Rows[0]["NecesariaVIII"].ToString());

                obj.DeseableI = int.Parse(DT.Rows[0]["DeseableI"].ToString());
                obj.DeseableII = int.Parse(DT.Rows[0]["DeseableII"].ToString());
                obj.DeseableIII = int.Parse(DT.Rows[0]["DeseableIII"].ToString());
                obj.DeseableIV = int.Parse(DT.Rows[0]["DeseableIV"].ToString());
                obj.DeseableV = int.Parse(DT.Rows[0]["DeseableV"].ToString());
                obj.DeseableVI = int.Parse(DT.Rows[0]["DeseableVI"].ToString());
                obj.DeseableVII = int.Parse(DT.Rows[0]["DeseableVII"].ToString());
                obj.DeseableVIII = int.Parse(DT.Rows[0]["DeseableVIII"].ToString());

                obj.Fisica = DT.Rows[0]["Fisica"].ToString();
                obj.OtrosI = DT.Rows[0]["OtrosI"].ToString();
                obj.OtrosII = DT.Rows[0]["OtrosII"].ToString();

                obj.EquivalenciasI = DT.Rows[0]["Equivalencias"].ToString();
                obj.EquivalenciasII = DT.Rows[0]["EquivalenciasII"].ToString();

                obj.Temas = new List<Tema>();
                int renglon = 1;
                foreach (DataRow item in DT.Rows)
                {
                    Tema T = new Tema();
                    T.Codigo = int.Parse(item["Curso"].ToString());
                    T = T.BuscarUno_Tema(T.Codigo.ToString());
                    T.Necesaria = item["NecesariaCurso"].ToString().ToUpper();
                    T.Deseable = item["DeseableCurso"].ToString().ToUpper();
                    obj.Temas.Add(T);
                    renglon++;
                }

            }
            return obj;
        }


        public DataTable ListarLegajosPorPerfil(int Desde, int Hasta)
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT distinct L.Perfil, L.ImprePerfil, L.Codigo, L.Descripcion, L.Version,  L.FechaVersion  FROM Legajo L where L.perfil between "+ Desde +" and "+ Hasta + " order by L.Perfil, L.Codigo desc";

            return repo.Listar(consulta);
        }

        public DataTable ListarTodosInicio()
        {
            Conexion repo = new Conexion();
            string consulta = "SELECT T.Codigo, T.Descripcion as Perfil,T.Vigencia,T.Version, " +
            "S.Descripcion as Sector, T.TareasI as Descripcion " +
            "FROM Tarea T LEFT OUTER JOIN Sector S on S.Codigo = T.Sector " +
            "where T.Renglon = 1   order by T.Codigo asc";
            
            return repo.Listar(consulta);
        }

        public DataTable ListarCursos(int Codigo)
        {
            Conexion repo = new Conexion();
            string consulta = "select C.codigo, C.descripcion, T.NecesariaCurso, T.DeseableCurso from Tarea T inner join Curso C on C.codigo = T.Curso where T.Codigo = " + Codigo;

            return repo.Listar(consulta);
        }

        public DataTable ListarPerfilEsp(int Desde, int Hasta)
        {
            Conexion repo = new Conexion();
            string consulta = "select T.Codigo, T.Descripcion, T.Vigencia, T.Sector,  S.Descripcion,  T.Version,"
                + " T.TareasI, T.TareasII, T.TareasIII, T.DescriI as EspPrim, "
                + " T.ObservaI as ObservPrim, T.NecesariaI as NecPrim, T.DeseableI as DesPrim ,"
                + " T.DescriII as EspSec, T.ObservaII as ObservSec, T.NecesariaII as NecSec, T.DeseableII as DesSec, T.DescriIII as EspTerc,"
                + " T.ObservaIII as ObservTerc, T.NecesariaIII as NecTerc, T.DeseableIII as DesTerc,"
                + " T.DescriIV as EspIdioma, T.ObservaIV as ObservIdioma, T.NecesariaIV as NecIdioma, T.DeseableIV as Desidioma,"
                + " T.DescriV as EspExp, T.ObservaV as ObservExp, T.NecesariaV as NecExp, T.DeseableV as DesExp,"
                + " T.Fisica as EspCondFis, T.NecesariaVI as NecCondFis, T.DeseableVI as DesCondFis,"
                + " T.OtrosI as EspOtrosI, T.NecesariaVII as NecOtrosI, T.DeseableVII as DesOtrosI,"
                + " T.OtrosII as EspOtrosII, T.NecesariaVIII as NecOtrosII, T.DeseableVIII as DesOtrosII,"
                + " T.Equivalencias as EquivI, T.EquivalenciasII as EquivII, T.Curso, C.descripcion, T.NecesariaCurso, T.DeseableCurso"
                + " from Tarea T inner join Sector S on S.codigo = T.Sector inner join Curso C on C.Codigo = T.Curso"
                + "  where T.Codigo >= " + Desde + " and T.codigo <= " +Hasta + " order by T.codigo, T.Renglon asc";
                

            return repo.Listar(consulta);
        }
    }
}
