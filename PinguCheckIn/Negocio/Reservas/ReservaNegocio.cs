using PinguCheckIn.Models.Dtos;
using PinguCheckIn.Models.Entidades;
using PinguCheckIn.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinguCheckIn.Negocio.Reservas
{
    public class ReservaNegocio : NegocioBase
    {
        public string Reservar(ReservaDto reserva)
        {
            try
            {
                var clienteId = this.Contexto.Cliente.Where(d => d.IdUsuario == reserva.IdUsuario).Select(d => d.IdCliente).FirstOrDefault();
                Pagamento p = new Pagamento(reserva.NomeCartao, reserva.NumeroCartao, reserva.Dataexp, reserva.Cvv, reserva.Aceito, reserva.Nome, reserva.Sobrenome, reserva.Email, reserva.Endereco, reserva.Endereco2, reserva.Pais, reserva.Estado, reserva.Cep, reserva.TipoPagamento, clienteId);
                this.Contexto.Add(p);
                this.Contexto.SaveChanges();

                var idPagamento = this.Contexto.Pagamentos.Where(d => d.IdCliente == clienteId).OrderByDescending(x => x.IdPagamento).FirstOrDefault();
                Reserva r = new Reserva(reserva.DataEntrada, reserva.DataSaida, DateTime.Now, reserva.ValorTotal, 1, clienteId, reserva.IdQuarto, idPagamento.IdPagamento);
                this.Contexto.Add(r);
                this.Contexto.SaveChanges();

                return "Sucesso";
            }
            catch(Exception e)
            {
                return e.Message;
            }


        }

        public List<AdministradorControleDto> ReservasFeitas()
        {
            var reservar = (from r in this.Contexto.Reserva
                            join q in this.Contexto.Quarto on r.IdQuarto equals q.IdQuarto
                            join c in this.Contexto.Cliente on r.IdCliente equals c.IdCliente
                            join u in this.Contexto.Usuario on c.IdUsuario equals u.IdUsuario
                            select new AdministradorControleDto
                            {
                                IdReserva = r.IdReserva,
                                Nome = u.Nome.ToUpper(),
                                Sobrenome = u.Sobrenome.ToUpper(),
                                Quarto = q.Nome,
                                Entrada = r.DataEntrada,
                                Saida = r.DataSaida,
                                Status = r.Status,
                                StatusString = ((Status)r.Status).ToString(),
                                DataReserva = r.DataReserva

                            }).ToList();

            return reservar;
        }

        public string FinalizarReservas()
        {

            var reservas = this.Contexto.Reserva.Where(d => d.DataSaida < DateTime.Now && d.Status == (int)Status.Reservado ).ToList();

            if (!reservas.Any())
            {
                return "Nenhuma reserva encontrada";
            }

            foreach(var r in reservas)
            {
                r.Status = (int)Status.Finalizada;
            }

            this.Contexto.SaveChanges();

            return "reservas finalizadas com sucesso";
        }
    }
}
