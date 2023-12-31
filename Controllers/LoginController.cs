﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrabajoFinalSofttek.DTOs;
using TrabajoFinalSofttek.Helpers;
using TrabajoFinalSofttek.Services;

namespace TrabajoFinalSofttek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Login con cuil y clave de Usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna Ok(200) si se loguea o Unauthorized(401) si algun dato es incorrecto</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var usuarioCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (usuarioCredentials is null) return Unauthorized("Datos incorrectos");

            var token = _tokenJwtHelper.GenerateToken(usuarioCredentials);

            var usuario = new UsuarioLoginDto()
            {
                Cuil = usuarioCredentials.Cuil,
                Nombre = usuarioCredentials.Nombre,
                Apellido = usuarioCredentials.Apellido,
                Token = token
            };


            return Ok(usuario);

        }
    }
}
