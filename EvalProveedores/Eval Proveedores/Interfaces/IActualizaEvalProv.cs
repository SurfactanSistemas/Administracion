using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eval_Proveedores.Interfaces
{
    interface IActualizaEvalProv
    {
        void _ProcesarActualizaEvalProv(string Proveedor, string Articulo, int Estado, string FechaEval, string FechaVto);
    }
}
