using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinguCheckIn.Data;
using PinguCheckIn.Models;
using PinguCheckIn.Models.Entidades;
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
        private readonly PinguCheckInContext Contexto;

        public LoginsController(PinguCheckInContext context)
        {
            Contexto = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginCredencial login)
        {
            // recupera o usuario
            var user = this.Contexto.Usuario.Where(u => u.Email.ToUpper() == (login.Email.ToUpper())).FirstOrDefault();


            //Verifica se o usuário existe
            if (user == null)
            {
                return NotFound(new { message = "Email não cadastrado." });
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

        [HttpGet]
        [Route("usuarios")]
        public IActionResult user()
        {
            return Ok(this.Contexto.Cliente.ToList());
        }


        [HttpPost]
        [Route("Cadastro")]
        public IActionResult Cadastro([FromBody] Usuario usuario)
        {
            var validaCpf = this.Contexto.Usuario.Where(d => d.Cpf.Trim() == usuario.Cpf.Trim());
            var validaEmail = this.Contexto.Usuario.Where(d => d.Email.Trim() == usuario.Email.Trim());

            if (validaCpf.Any())
            {
                return BadRequest("CPF já cadastrado");
            }
            if (validaEmail.Any())
            {
                return BadRequest("Email já cadastrado");
            }


            this.Contexto.Add(usuario);
            this.Contexto.SaveChanges();

            int idUsuarioCadastrado = this.Contexto.Usuario.Where(c => c.Cpf.Trim() == usuario.Cpf.Trim()).Select(c => c.IdUsuario).FirstOrDefault();


            Cliente cliente = new Cliente(null, null, null, null, null, null, null, null, idUsuarioCadastrado);

            this.Contexto.Add(cliente);
            this.Contexto.SaveChanges();


           
            return Ok(new
            {
                mensagem = "Usuario cadastrado com sucesso."
            });
        }

    }
}
