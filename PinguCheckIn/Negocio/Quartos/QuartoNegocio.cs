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

            var quartos = this.Contexto.Quarto.ToList();

            var quartosNaoDisponiveis = (from reserva in this.Contexto.Reserva
                                      join quarto in this.Contexto.Quarto on reserva.IdQuarto equals quarto.IdQuarto
                                      where reserva.DataEntrada <= filtro.DataSaida && filtro.DataEntrada <= reserva.DataSaida
                                      select quarto).ToList();

           
            var r = quartosNaoDisponiveis;

            List<QuartoDto> quartoList = new List<QuartoDto>();

            if (quartosNaoDisponiveis.Any())
            {
                foreach(var q in quartosNaoDisponiveis)
                {
                    quartos.Remove(q);
                }
            }


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

            return quartoList;
        }

        public bool QuartoDisponivel(FiltroQuarto filtro)
        {
            var quartosNaoDisponiveis = (from reserva in this.Contexto.Reserva
                                         join quarto in this.Contexto.Quarto on reserva.IdQuarto equals quarto.IdQuarto
                                         where quarto.IdQuarto == filtro.IdQuarto && reserva.DataEntrada <= filtro.DataSaida & filtro.DataEntrada <= reserva.DataSaida
                                         select quarto).ToList();


            return !quartosNaoDisponiveis.Any();
        }
         
    }
}
