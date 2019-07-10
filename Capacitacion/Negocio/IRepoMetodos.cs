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
