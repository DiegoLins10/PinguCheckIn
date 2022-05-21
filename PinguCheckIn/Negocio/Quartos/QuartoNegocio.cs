using PinguCheckIn.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Negocio.Quartos
{
    public class QuartoNegocio : NegocioBase
    {
        
        public List<QuartoDto> Quartos(FiltroQuarto filtro)
        {
            var sl = this.Contexto.Reserva.ToList();

            var quartosDisponiveis = (from reserva in this.Contexto.Reserva
                                      where reserva.DataEntrada < filtro.DataSaida && filtro.DataEntrada < reserva.DataSaida
                                      select reserva);

           
            var r = quartosDisponiveis;

            return null;
        }
         
    }
}
