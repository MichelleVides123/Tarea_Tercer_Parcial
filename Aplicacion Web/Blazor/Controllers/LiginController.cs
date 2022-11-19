﻿using Datos.Interfaces;
using Datos.Repositorios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;

namespace Blazor.Controllers
{
    public class LiginController : Controller
    {
        private readonly Config _configuracion;
        private ILogingRepositorio _loginRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;

        public LiginController(Config config)
        {
            _configuracion = config;
            _loginRepositorio = new LogingRepositorio(config.CadenaConexion);
            _usuarioRepositorio = new UsuarioRepositorio(config.CadenaConexion);

        }


        [HttpPost("/account/login")]
        public async Task<IActionResult> Login(Login login)
        {
            string rol = string.Empty;
            try
            {
                bool usuarioValido = await _loginRepositorio.ValidacionUsuario(login);

                if (usuarioValido)
                {
                    Usuario user = await _usuarioRepositorio.GetPorCodigo(login.Usuario);

                    if (user.EstadoActivo)
                    {
                        rol = user.Rol;

                        var clains = new[]
                        {
                            new Claim(ClaimTypes.Name, user.Codigo),
                            new Claim(ClaimTypes.Role, rol)
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(clains, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTime.UtcNow.AddMinutes(5)});

                    }
                    else
                    {
                        return LocalRedirect("login/El usuario no esta activo");
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }
        

    }
}
