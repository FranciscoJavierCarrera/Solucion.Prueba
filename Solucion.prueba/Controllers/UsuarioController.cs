using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Solucion.prueba.Dtos;
using Solucion.prueba.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Solucion.prueba.Controllers
{
    public class UsuarioController : BaseApiController
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ITokenService _tokenService;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto login)
        {
            var usuario = await _userManager.FindByEmailAsync(login.email);
            if (User == null)
            {
                return Unauthorized(new CodeErrorResponse(401));
            }
            var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, login.password, false);
            if (!resultado.Succeeded)
            {
                return Unauthorized(new CodeErrorResponse(401, "Error en la contraseña"));
            }
            return new UsuarioDto
            {
                Email = usuario.Email,
                UserName = usuario.UserName,
                Token = _tokenService.CreateToken(usuario),

            };
        }

        /// <summary>
        /// Registro de un nuevo usuario
        /// </summary>
        /// <returns>Cliente</returns>
        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDto>> PostRegistro(UsuarioRegistroDto usuario)
        {
            var Usuario = new Usuario
            {
                Email = usuario.Email,
                Apellidos = usuario.Apellido,
                Nombre = usuario.Nombre,
                UserName = usuario.UserName
            };
            var resultado =await  _userManager.CreateAsync(Usuario, usuario.Password);
            if (!resultado.Succeeded)
            {
                return Unauthorized(new CodeErrorResponse(400, "Error al crear el nuevo usuario"));
            }
            return new UsuarioDto
            {
                Email = Usuario.Email,
                UserName = Usuario.UserName,
                Token = _tokenService.CreateToken(Usuario),
            };
           
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> GetUsuario() {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x=> x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            return new UsuarioDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        } 



    }
}
