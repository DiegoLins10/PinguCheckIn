using Microsoft.AspNetCore.Mvc;
using PinguCheckIn.Data;
using PinguCheckIn.Negocio.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoricoController : Controller
    {
        private readonly PinguCheckInContext _context;

        public HistoricoController(PinguCheckInContext context)
        {
            _context = context;
        }

        [HttpGet("GetHistorico")]
        public IActionResult RetornarHistorico(int idUsuario)
        {
            try
            {
                var dados = new HistoricoNegocio().RetornarReservas(idUsuario);

                if (!dados.Any())
                {
                    return NotFound("Nenhuma transação encontrada");
                }

                return Ok(dados);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpGet("GetCancelar")]
        public IActionResult Cancelar(int idReserva)
        {
            string dados = new HistoricoNegocio().CancelarReserva(idReserva);

            return Ok(new { msg = dados});
        }

        [HttpGet("GetFinalizar")]
        public IActionResult Finalizar(int idReserva)
        {
            string dados = new HistoricoNegocio().FinalizarReserva(idReserva);

            return Ok(new { msg = dados });
        }
    }
}
