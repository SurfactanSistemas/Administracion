using System;
using System.Collections.Generic;
using System.Data;
using ClassConexion;

//using Negocio;

namespace Negocio
{
    public class PerfilVersion: IRepoMetodos<PerfilVersion>
    {
        public int Codigo;
        public string Descripcion;
        public string DesdeVigencia;
        public string HastaVigencia;
        public int Version;

        public Sector sector;

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

            foreach (var t in Temas)
            {
                var clave1 = Codigo.ToString().PadLeft(6, '0');
                var clave2 = Version.ToString().PadLeft(4, '0');
                var clave3 = renglon.ToString().PadLeft(2, '0');
                

                string consulta = "insert into TareaVersion "
                + " (Clave,Codigo,Renglon,Descripcion,DesdeVigencia, HastaVigencia, Sector, TareasI, TareasII, TareasIII,DescriI, DescriII,DescriIII, DescriIV,"
                + " DescriV, ObservaI, ObservaII,ObservaIII,ObservaIV,ObservaV,NecesariaI,NecesariaII,NecesariaIII,NecesariaIV,NecesariaV,"
                + " DeseableI,DeseableII,DeseableIII,DeseableIV,DeseableV, Equivalencias, Fisica, OtrosI, OtrosII, Curso,NecesariaCurso, DeseableCurso,"
                + " Version,NecesariaVI, NecesariaVII, NecesariaVIII, DeseableVI,DeseableVII,DeseableVIII,EquivalenciasII)"
                + " values"
                + "('" + clave1 + clave2 + clave3 + "'," + Codigo + "," + renglon + ",'" + Descripcion + "','" + DesdeVigencia + "','" + HastaVigencia + "'," 
                + sector.Codigo + ",'" + TareasI + "','" + TareasII + "','" + TareasIII
                + "','" + DescriI + "','" + DescriII + "','" + DescriIII + "','" + DescriIV + "','" + DescriV + "','" + ObservaI + "','" + ObservaII + "','"
                + ObservaIII + "','" + ObservaIV + "','" + ObservaV + "'," + NecesariaI + "," + NecesariaII + "," + NecesariaIII + "," + NecesariaIV
                + "," + NecesariaV + "," + DeseableI + "," + DeseableII + "," + DeseableIII + "," + DeseableIV + "," + DeseableV + ",'" + EquivalenciasI + "','"
                + Fisica + "','" + OtrosI + "','" + OtrosII + "'," + t.Codigo + "," + t.Necesaria + "," + t.Deseable + "," + Version + "," + NecesariaVI
                + "," + NecesariaVII + "," + NecesariaVIII + "," + DeseableVI + "," + DeseableVII + "," + DeseableVIII + ",'" + EquivalenciasII + "')";
                
                repo.Agregar(consulta);

                renglon++;
            }
        }

        public PerfilVersion BuscarUno(string IdAModificar)
        {
            return null;
        }

        public PerfilVersion BuscarUno(string IdAModificar, string ver)
        {
            Conexion repo = new Conexion();
            string consulta = "select * from TareaVersion where Codigo = " + IdAModificar + " and Version = " + ver;
            DataTable DT = repo.BuscarUno(consulta);
            PerfilVersion obj = new PerfilVersion();

            if (DT.Rows.Count > 0)
            {
                obj.Codigo = int.Parse(DT.Rows[0]["Codigo"].ToString());
                //obj.Curso = int.Parse(DT.Rows[0])
                obj.Descripcion = DT.Rows[0]["Descripcion"].ToString();
                obj.Version = int.Parse(DT.Rows[0]["Version"].ToString());
                obj.DesdeVigencia = DT.Rows[0]["DesdeVigencia"].ToString();
                obj.HastaVigencia = DT.Rows[0]["HastaVigencia"].ToString();
                //Responsable R1 = new Responsable();
                //R1 = R1.BuscarUno(DT.Rows[0]["Responsable"].ToString());
                //obj.R = R1;

                //Responsable R2 = new Responsable();
                //R2 = R2.BuscarUno(DT.Rows[0]["ResponsableII"].ToString());
                //obj.R2 = R2;

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



                obj.NecesariaI = ParsearValor(DT.Rows[0]["NecesariaI"].ToString());
                obj.NecesariaII = ParsearValor(DT.Rows[0]["NecesariaII"].ToString());
                obj.NecesariaIII = ParsearValor(DT.Rows[0]["NecesariaIII"].ToString());
                obj.NecesariaIV = ParsearValor(DT.Rows[0]["NecesariaIV"].ToString());
                obj.NecesariaV = ParsearValor(DT.Rows[0]["NecesariaV"].ToString());
                obj.NecesariaVI = ParsearValor(DT.Rows[0]["NecesariaVI"].ToString());
                obj.NecesariaVII = ParsearValor(DT.Rows[0]["NecesariaVII"].ToString());
                obj.NecesariaVIII = ParsearValor(DT.Rows[0]["NecesariaVIII"].ToString());

                obj.DeseableI = ParsearValor(DT.Rows[0]["DeseableI"].ToString());
                obj.DeseableII = ParsearValor(DT.Rows[0]["DeseableII"].ToString());
                obj.DeseableIII = ParsearValor(DT.Rows[0]["DeseableIII"].ToString());
                obj.DeseableIV = ParsearValor(DT.Rows[0]["DeseableIV"].ToString());
                obj.DeseableV = ParsearValor(DT.Rows[0]["DeseableV"].ToString());
                obj.DeseableVI = ParsearValor(DT.Rows[0]["DeseableVI"].ToString());
                obj.DeseableVII = ParsearValor(DT.Rows[0]["DeseableVII"].ToString());
                obj.DeseableVIII = ParsearValor(DT.Rows[0]["DeseableVIII"].ToString());

                obj.Fisica = DT.Rows[0]["Fisica"].ToString();
                obj.OtrosI = DT.Rows[0]["OtrosI"].ToString();
                obj.OtrosII = DT.Rows[0]["OtrosII"].ToString();

                obj.EquivalenciasI = DT.Rows[0]["Equivalencias"].ToString();
                obj.EquivalenciasII = DT.Rows[0]["EquivalenciasII"].ToString();

                obj.Temas = new List<Tema>();
                //FALTA TEMAS
                int renglon = 1;
                foreach (DataRow item in DT.Rows)
                {
                    Tema T = new Tema();
                    T.Codigo = int.Parse(item["Curso"].ToString());
                    //T = T.BuscarUno(T.Codigo.ToString(), renglon);
                    T = T.BuscarUno_Tema(T.Codigo.ToString());
                    //T.Descripcion = T.
                    T.Necesaria = item["NecesariaCurso"].ToString();
                    T.Deseable = item["DeseableCurso"].ToString();
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

        private int ParsearValor(string p)
        {
            int perver = 0;
            int.TryParse(p, out perver);
            return perver;
        }

        public void Modificar(PerfilVersion t)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(string IdAEliminar)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarVersion(int Codigo)
        {
            Conexion repo = new Conexion();
            string consulta = "select distinct T.Version from TareaVersion T where Codigo = "  + Codigo;
            return repo.Listar(consulta);
        }
    }
}
