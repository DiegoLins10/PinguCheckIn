using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinguCheckIn.Data;
using PinguCheckIn.Models;
using PinguCheckIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PinguCheckIn.Controllers
{
    [AllowAnonymous]
    [Route("")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly PinguCheckInContext _context;

        public LoginsController(PinguCheckInContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginCredencial login)
        {
            // recupera o usuario
            var user = this._context.Usuario.Where(u => u.Username.ToUpper() == (login.Username.ToUpper())).FirstOrDefault();


            //Verifica se o usuário existe
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha invalidos" });
            }

            if (!user.Senha.Equals(login.Senha))
            {
                return BadRequest(new { message = "Senha incorreta" });
            }

            // Gera token 
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return Ok(new
            {
                user = user,
                token = token
            });
        }

    }
}
