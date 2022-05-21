using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinguCheckIn.Data;
using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Entidades;
using PinguCheckIn.Negocio.Quartos;

namespace PinguCheckIn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuartosController : Controller
    {
        private readonly PinguCheckInContext _context;

        public QuartosController(PinguCheckInContext context)
        {
            _context = context;
        }

        // GET: Quartos
        [HttpGet]
        public async Task<IActionResult> GetQuartos()

        {

            var quartos = await _context.Quarto.ToListAsync();

            if (!quartos.Any())
            {
                return NotFound("Nenhum quarto encontrado");
            }

            List<QuartoDto> quartoList = new List<QuartoDto>();

            

            foreach(var q in quartos)
            {
                QuartoDto qDto = new QuartoDto();

                qDto.Acomoda = q.Acomoda;
                qDto.Beneficios = q.Beneficios.Split(";");
                qDto.IdQuarto = q.IdQuarto;
                qDto.Imagem = q.Imagem;
                qDto.Nome = q.Nome;
                qDto.QtdCamas = q.QtdCamas;
                qDto.Tamanho = q.Tamanho;
                qDto.Valor = q.Valor;
                quartoList.Add(qDto);
            }

            

            return Ok(quartoList);
        }

        [HttpGet("GetQuartosFiltro")]
        public IActionResult GetQuartosFiltro()
        {

            var quartos = _context.Quarto.ToList();

            if (!quartos.Any())
            {
                return NotFound("Nenhum quarto encontrado");
            }

            List<QuartoDto> quartoList = new List<QuartoDto>();



            foreach (var q in quartos)
            {
                QuartoDto qDto = new QuartoDto();

                qDto.Acomoda = q.Acomoda;
                qDto.Beneficios = q.Beneficios.Split(";");
                qDto.IdQuarto = q.IdQuarto;
                qDto.Imagem = q.Imagem;
                qDto.Nome = q.Nome;
                qDto.QtdCamas = q.QtdCamas;
                qDto.Tamanho = q.Tamanho;
                qDto.Valor = q.Valor;
                quartoList.Add(qDto);
            }

            var teste = new QuartoNegocio().Quartos(new FiltroQuarto { DataEntrada = new DateTime(2022, 06, 14), DataSaida = new DateTime(2022, 06, 17)});

            return Ok(quartoList);


        }
            
    }
}
