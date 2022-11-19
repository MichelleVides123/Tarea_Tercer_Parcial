using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private string CadenaConexion;

        public UsuarioRepositorio(string _cadenaconexion)
        {
            CadenaConexion = _cadenaconexion;
        }


        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public Task<bool> Actualizar(Usuario ususario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetLista()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM usuarioo WHERE Codigo = @Codigo;";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        public Task<bool> Nuevo(Usuario ususario)
        {
            throw new NotImplementedException();
        }
    }
}
