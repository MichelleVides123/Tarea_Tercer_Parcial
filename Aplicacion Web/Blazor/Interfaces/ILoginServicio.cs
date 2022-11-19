using Modelos;

namespace Blazor.Innterfaces
{
    public interface ILoginServicio
    {
        Task<bool> ValidacionUsuario(Login login);
    }
}
