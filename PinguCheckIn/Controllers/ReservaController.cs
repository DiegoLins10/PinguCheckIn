using Microsoft.AspNetCore.Mvc;
using PinguCheckIn.Data;
using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Entidades;
using PinguCheckIn.Negocio.Csv;
using PinguCheckIn.Negocio.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


        //[HttpGet]
        //[Route("baixar")]
        //public HttpResponseMessage Baixar()
        //{
        //    var file = new RelatoriosNegocio().GerarRelatorio();

        //    //return File(System.IO.File.ReadAllBytes(path), "application/octet-stream", fileName);

        //    var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(System.IO.File.ReadAllBytes(file.Path))
        //    };

        //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = file.FileName
        //    };
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");

        //    return result;
        //}

        [HttpGet("baixar")]
        public FileContentResult Get(string status, string periodo)
        {
            var file = new RelatoriosNegocio().GerarRelatorio(status, periodo);
            return File(System.IO.File.ReadAllBytes(file.Path), "text/csv", file.FileName);
        }

        [HttpGet("FinalizarReservas")]
        public IActionResult FinalizarReservas(string status, string periodo)
        {
            try
            {
                string res = new ReservaNegocio().FinalizarReservas();       
                return Ok(new { msg = res });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

    }
}
