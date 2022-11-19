using Blazor.Innterfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private readonly Config _configuracion;
        private ILogingRepositorio LoginRepositorio;

        public LoginServicio(Config config)
        {
            _configuracion = config;
            LoginRepositorio = new LogingRepositorio(config.CadenaConexion);
        }

        public Task<bool> ValidacionUsuario(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
