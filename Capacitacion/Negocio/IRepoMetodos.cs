using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Negocio
{
    interface IRepoMetodos<T>
    {
        DataTable ListarTodos();

        int ObtenerUltimoId();

        void Agregar();

        T BuscarUno(string IdAModificar);

        void Modificar(T t);

        void Eliminar(string IdAEliminar);
    }
}
