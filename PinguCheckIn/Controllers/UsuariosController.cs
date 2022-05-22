using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinguCheckIn.Data;
using PinguCheckIn.Models;
using PinguCheckIn.Models.Dtos;

namespace PinguCheckIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly PinguCheckInContext _context;

        public UsuariosController(PinguCheckInContext context)
        {
            _context = context;
        }



        // GET: api/Usuarios
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = (from user in this._context.Usuario
                           join cliente in this._context.Cliente on user.IdUsuario equals cliente.IdUsuario
                           where user.IdUsuario == id
                           select new DadosDto
                           {
                               Sexo = cliente.Sexo,
                               Nacionalidade = cliente.Nacionalidade,
                               Logradouro = cliente.Logradouro,
                               Bairro = cliente.Bairro,
                               Cep = cliente.Cep,
                               Cidade = cliente.Cidade,
                               Uf = cliente.Cidade,
                               Complemento = cliente.Cidade,
                               Nome = user.Nome,
                               Email = user.Email,
                               Sobrenome = user.Sobrenome,
                               Cpf = user.Cpf,
                               Rg = user.Rg,
                               Celular = user.Celular,
                               DataNascimento = user.DataNascimento,
                               Funcionario = user.Funcionario
                           }) ;

            if (usuario == null)
            {
                return NotFound("Usuario não encontrado.");
            }

            return Ok(usuario);
        }



        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
