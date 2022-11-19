using Modelos;

namespace Datos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> GetPorCodigo(string codigo);
        Task<bool> Nuevo(Usuario ususario);
        Task<bool> Actualizar(Usuario ususario);
        Task<bool> Eliminar(string codigo);
        Task<IEnumerable<Usuario>> GetLista();
    }
}


