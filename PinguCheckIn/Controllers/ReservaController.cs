using Microsoft.AspNetCore.Mvc;
using PinguCheckIn.Data;
using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Entidades;
using PinguCheckIn.Negocio.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly PinguCheckInContext _context;

        public ReservaController(PinguCheckInContext context)
        {
            _context = context;
        }

        [HttpGet("estados")]
        public IActionResult GetEstados()
        {
            var estados = this._context.Estados.ToList();

            if (!estados.Any())
            {
                return NotFound("Não existem estados cadastrados");
            }

            return Ok(estados);
        }

        [HttpPost("salvar")]
        public IActionResult Salvar(ReservaDto reserva)
        {
            string msg = new ReservaNegocio().Reservar(reserva);

            return Ok(new { msg = msg });
        }

        [HttpGet("GetAdmReservas")]
        public IActionResult AdmReservas()
        {

            try
            {
                var list = new ReservaNegocio().ReservasFeitas();

                if(list.Count == 0)
                {
                    return NotFound("Nenhuma reserva encontrada");
                }

                return Ok(list);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
       
        }
    }
}
