using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Eval_Proveedores.Clases
{
    enum Secciones
    {
        EvalMPCalidad,
        EvalMPEntrega,
        EvalTransporte,
        EvalMantenimiento,
        EvalCalibracion,
        EvalOtrosServicios,
        EvalEnvases
    }

    class Habilitame
    {
        public static bool Evaluar(Secciones Seccion, string Clave)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["SurfactanSa"].ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Operador WHERE UPPER(Clave) = '" + Clave.ToUpper() + "'";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            switch (Seccion)
                            {
                                case Secciones.EvalMPCalidad:
                                {
                                    return Helper.OrDefault(dr["EvalProv1"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalMPEntrega:
                                {
                                    return Helper.OrDefault(dr["EvalProv2"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalTransporte:
                                {
                                    return Helper.OrDefault(dr["EvalProv3"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalMantenimiento:
                                {
                                    return Helper.OrDefault(dr["EvalProv4"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalCalibracion:
                                {
                                    return Helper.OrDefault(dr["EvalProv5"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalOtrosServicios:
                                {
                                    return Helper.OrDefault(dr["EvalProv6"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                                case Secciones.EvalEnvases:
                                {
                                    return Helper.OrDefault(dr["EvalProv7"], "N").ToString().ToUpper() == "S";
                                    break;
                                }
                            }

                        }
                    }
                }

            }
        
            return false;
        }
    }
}
